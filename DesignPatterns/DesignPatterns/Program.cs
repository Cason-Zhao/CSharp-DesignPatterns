using DesignPatterns.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Message.Insert(new MessageModel("插入测试数据", DateTime.Now)));

            var firstMsg = Message.Get().First();
            Console.WriteLine($"{firstMsg.Message}, {firstMsg.PublishDate.ToString("yyyy-MM-dd HH:mm:ss")}");

            Console.ReadKey();
        }
    }
}
