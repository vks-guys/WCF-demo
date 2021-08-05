using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace HelloServices
{
    public class HelloService : IHelloService
    {
        public string GetMessage(string name)
        {
            var tokenval = GetHeader("token", "ns");
            Console.WriteLine(tokenval);

            var nameval = GetHeader("name", "ns");
            Console.WriteLine(nameval);
            //throw new Exception("Hii");
            if (nameval == "vivek")
            {
                return null;
            }
            return "Hello " + name;
        }

        public static string GetHeader(string name, string ns)
        {
            return OperationContext.Current.IncomingMessageHeaders.FindHeader(name, ns) > -1 ?
                OperationContext.Current.IncomingMessageHeaders.GetHeader<string>(name, ns) : string.Empty;
        }
    }
}
