using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Provider
{
    internal class MessageProviderConfigurationSection: ConfigurationSection
    {
        private readonly ConfigurationProperty _DefaultProvider;
        [ConfigurationProperty(nameof(DefaultProvider))]
        public string DefaultProvider
        {
            get { return (string)base[_DefaultProvider]; }
            set { base[_DefaultProvider] = value; }
        }

        private readonly ConfigurationProperty _Providers;
        [ConfigurationProperty(nameof(Providers), DefaultValue = "SqlMessageProvider")]
        [StringValidator(MinLength =1)]
        public ProviderSettingsCollection Providers
        {
            get { return (ProviderSettingsCollection)base[_Providers]; }
        }

        private ConfigurationPropertyCollection _Properties;
        protected override ConfigurationPropertyCollection Properties
        {
            get { return this._Properties; }
        }

        public MessageProviderConfigurationSection()
        {
            _DefaultProvider = new ConfigurationProperty("DefaultProvider", typeof(string), null);
            _Providers = new ConfigurationProperty("Providers", typeof(ProviderSettingsCollection), null);

            _Properties = new ConfigurationPropertyCollection();
            _Properties.Add(_DefaultProvider);
            _Properties.Add(_Providers);
            
        }

    }
}
