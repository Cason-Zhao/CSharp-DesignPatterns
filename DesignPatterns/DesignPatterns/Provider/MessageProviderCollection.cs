using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Provider
{
    internal class MessageProviderCollection: ProviderCollection
    {
        public override void Add(ProviderBase provider)
        {
            if(provider == null)
            {
                throw new ArgumentNullException("provider不可为空！");
            }
            if(!typeof(MessageProvider).IsAssignableFrom(provider.GetType()))
            {
                throw new ArgumentException("provider 参数类型必须是或继承自MessageProviderBase");
            }
            base.Add(provider);
        }
    }
}
