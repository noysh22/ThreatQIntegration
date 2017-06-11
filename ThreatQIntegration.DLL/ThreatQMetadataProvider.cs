using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Siemplify.Common;
using Siemplify.Common.Extensions;

namespace Siemplify.Integrations.ThreatQ
{
    public class ThreatQMetadataProvider : MetadataProviderBase
    {
        public const string ProviderIdentifier = "ThreadQ";
        private List<ModuleSettingsProperty> _requiredSettings = null;

        public ThreatQMetadataProvider()
        {
            ProviderIcon = "Siemplify.Integrations.ThreadQ.Resources.threatq.png";
        }

        public override Stream IconStream
        {
            get
            {
                var data = Convert.FromBase64String(IconBase64);
                var ms = new MemoryStream(data);
                return ms;
            }
        }

        public override string Identifier => ProviderIdentifier;

        public override string DisplayName => ProviderIdentifier;

        public override string Description
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append("https://www.threatq.com/");
                sb.Append(
                    @"Strengthen your security posture with a threat intelligence platform designed to enable threat operations and management and arm your analysts with the intelligence, controls and automation required to protect your business, employees and customers.");

                return sb.ToString();
            }
        }

        public override List<ModuleSettingsProperty> RequiredSettings
        {
            get
            {
                if (_requiredSettings == null)
                {
                    _requiredSettings = new List<ModuleSettingsProperty>
                    {
                        new ModuleSettingsProperty
                        {
                            ModuleName = Identifier,
                            PropertyName = Settings.ApiBaseHost,
                            PropertyDisplayName = Settings.ApiBaseHost,
                            PropertyType = ParamTypeEnum.String
                        },
                        new ModuleSettingsProperty
                        {
                            ModuleName = Identifier,
                            PropertyName = Settings.ApiUserName,
                            PropertyDisplayName = Settings.ApiUserName,
                            PropertyType = ParamTypeEnum.String
                        },
                        new ModuleSettingsProperty
                        {
                            ModuleName = Identifier,
                            PropertyName = Settings.ApiKey,
                            PropertyDisplayName = Settings.ApiKey,
                            PropertyType = ParamTypeEnum.Password
                        }
                    };
                }

                return _requiredSettings;
            }
        }

        public override Task Test(Dictionary<string, string> paramsWithValues)
        {
            var apiBaseHost = paramsWithValues.GetOrDefault(Settings.ApiBaseHost);
            if (apiBaseHost.IsEmpty())
            {
                throw new Exception(string.Format("Not found <{0}> Field.", Settings.ApiBaseHost));
            }

            var apiUsername = paramsWithValues.GetOrDefault(Settings.ApiUserName);
            if (apiUsername.IsEmpty())
            {
                throw new Exception(string.Format("Not found <{0}> Field.", Settings.ApiUserName));
            }

            var apiKey = paramsWithValues.GetOrDefault(Settings.ApiKey);
            if (apiKey.IsEmpty())
            {
                throw new Exception(string.Format("Not found <{0}> Field.", Settings.ApiKey));
            }

            throw new NotImplementedException();
        }
    }
}
