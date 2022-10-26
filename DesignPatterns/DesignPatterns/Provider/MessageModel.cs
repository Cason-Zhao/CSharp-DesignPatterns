using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Provider
{
    internal class MessageModel
    {
        public string Message { get; set; }
        public DateTime PublishDate { get; set; }

        public MessageModel(string message, DateTime publishDate)
        {
            this.Message = message;
            this.PublishDate = publishDate;
        }
    }
}
