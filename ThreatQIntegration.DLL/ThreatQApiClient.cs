using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Siemplify.Integrations.ThreatQ.Data;

namespace Siemplify.Integrations.ThreatQ
{
    public class ThreatQApiClient
    {
        private const string ApiHostFormat = "https://{0}/api";
        private const string GetApiTokenFormat = @"token?grant_type=password&client_id={0}";
        private const string AuthParamName = "Authorization";
        private const string AuthParamFormat = "{0} {1}";

        private readonly RestClient _client;
        private readonly ApiToken _token;

        // Set SSL security validation and protocol to allow to communicate with ThreatQ API
        // For now ignoring certificate errors
        static ThreatQApiClient()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        private static object CreateTokenRequestBody(string user, string pass)
        {
            return new { email = user, password = pass };
        }

        private static RestRequest CreateRestRequest(string url, Method method, object body = null)
        {
            var request = new RestRequest(url, method) { RequestFormat = DataFormat.Json };

            if (null != body)
            {
                request.AddJsonBody(body);
            }

            return request;
        }

        private static string GetSortOrderString(SortOrder order)
        {
            const string sortParam = "created_at";

            var sortString = sortParam;

            if (SortOrder.DESC == order)
            {
                sortString = sortParam.Insert(0, "-");
            }

            return sortString;
        }

        private static string GetAdditionalTypesString(ApiDataTypes includeTypes)
        {
            const string includeParamFormat = "&with={0}";
            const string separator = ",";

            if (ApiDataTypes.None == includeTypes)
            {
                return string.Empty;
            }

            var includeTypesList = new List<string>();

            if (includeTypes.HasFlag(ApiDataTypes.Type))
            {
                includeTypesList.Add(ApiDataTypes.Type.ToString().ToLower());
            }

            if (includeTypes.HasFlag(ApiDataTypes.Status))
            {
                includeTypesList.Add(ApiDataTypes.Status.ToString().ToLower());
            }

            if (includeTypes.HasFlag(ApiDataTypes.Sources))
            {
                includeTypesList.Add(ApiDataTypes.Sources.ToString().ToLower());
            }

            if (includeTypes.HasFlag(ApiDataTypes.Score))
            {
                includeTypesList.Add(ApiDataTypes.Score.ToString().ToLower());
            }

            return string.Format(includeParamFormat, string.Join(separator, includeTypesList));
        }

        public ThreatQApiClient(string host, string clientId, string user, string pass)
        {
            _client = new RestClient(string.Format(ApiHostFormat, host));

            _token = CreateApiToken(clientId, user, pass);
        }

        private ApiToken CreateApiToken(string clientId, string user, string pass)
        {
            var request = CreateRestRequest(string.Format(GetApiTokenFormat, clientId), Method.POST,
                CreateTokenRequestBody(user, pass));

            var response = _client.Execute<ApiToken>(request);

            return response.Data;
        }

        private RestRequest CreateRequestWithToken(string url, Method method, object body = null)
        {
            var request = CreateRestRequest(url, method, body);

            // Add the security token to the request
            request.AddParameter(AuthParamName,
                string.Format(AuthParamFormat,
                    CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_token.TokenType),
                    _token.AccessToken),
                ParameterType.HttpHeader);

            return request;
        }

        public async Task<string> GetRawIndicators(
            uint offset = 0,
            uint limit = 100,
            ApiDataTypes includeTypes = ApiDataTypes.None,
            SortOrder order = SortOrder.ASC)
        {
            const string indicatorsEndpointFormat = "/indicators?sort={0}";
            const string limitFormat = "&limit={0}";
            const string offsetFormat = "&offset={0}";

            var endpoint = string.Format(indicatorsEndpointFormat, GetSortOrderString(order));

            endpoint += GetAdditionalTypesString(includeTypes);

            endpoint += string.Format(limitFormat, limit);

            if (0 != offset)
            {
                endpoint += string.Format(offsetFormat, offset);
            }

            var request = CreateRequestWithToken(endpoint, Method.GET);

            var response = await _client.ExecuteTaskAsync(request);

            return response.Content;
        }
    }
}
