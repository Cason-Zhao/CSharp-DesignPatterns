using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Provider
{
    internal class SqlMessageProvider : MessageProvider
    {
        private string _ConnectionPath;

        public override bool Insert(MessageModel model)
        {
            return true;
        }

        public override IList<MessageModel> Get()
        {
            var result = new List<MessageModel>();
            result.Add(new MessageModel($"SQL 方式，连接字符串{this._ConnectionPath}", DateTime.Now));

            return result;
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            if(string.IsNullOrEmpty(name))
            {
                name = nameof(MessageProvider);
            }

            if(null == config)
            {
                throw new ArgumentNullException("config");
            }

            if (string.IsNullOrEmpty(config["Description"]))
            {
                config.Remove("Description");
                config.Add("Description", "SQLServer操作Message!");
            }

            base.Initialize(name, config);

            string connStrName = config["ConnectionPathName"];
            if(connStrName == null || connStrName.Length == 0)
            {
                throw new ProviderException("ConnectionPathName配置属性值为空或缺失！");
            }

            this._ConnectionPath = ConfigurationManager.ConnectionStrings[connStrName].ConnectionString;
            if(string.IsNullOrEmpty(_ConnectionPath))
            {
                throw new ProviderException("没找到" + connStrName + "所指的连接字符串，或所指连接字符串为空");
            }

            config.Remove("ConnectionStringName");
        }
    }
}
