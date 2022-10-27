using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DesignPatterns.Provider
{
    internal class Message
    {
        private static bool _IsInitialized = false;
        private static MessageProviderCollection _Providers;
        public static MessageProviderCollection Providers
        {
            get { return _Providers; }
        }

        private static MessageProvider _Provider;
        public static MessageProvider Provider
        {
            get { return _Provider; }
        }

        static Message()
        {
            Initialize();
        }

        public static bool Insert(MessageModel model)
        {
            _Provider.Insert(model);
            return true;
        }

        public static IList<MessageModel> Get()
        {
            return _Provider.Get();
        }

        private static void Initialize()
        {
            try
            {
                if(_IsInitialized)
                {
                    return;
                }

                var configSection = (MessageProviderConfigurationSection)ConfigurationManager.GetSection(nameof(MessageProvider));
                if(configSection == null)
                {
                    throw new Exception($"未在配置文件中找到\"{nameof(MessageProvider)}\"节点！");
                }

                _Providers = new MessageProviderCollection();
                ProvidersHelper.InstantiateProviders(configSection.Providers, _Providers, typeof(MessageProvider));
                _Provider = _Providers[configSection.DefaultProvider] as MessageProvider;

                _IsInitialized = true;
            }
            catch (Exception x)
            {
                // Log
                throw x;
            }
        }

    }
}
