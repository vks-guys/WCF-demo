using System;
using System.ServiceModel;

namespace HelloServices
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string GetMessage(string name);
    }
}
