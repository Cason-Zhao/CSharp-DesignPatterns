using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Provider
{
    internal abstract class MessageProvider: ProviderBase
    {
        public abstract bool Insert(MessageModel model);

        public abstract IList<MessageModel> Get();
    }
}
