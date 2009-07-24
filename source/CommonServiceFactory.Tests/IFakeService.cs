using System.ServiceModel;

namespace CommonServiceFactory.Tests
{
    [ServiceContract]
    public interface IFakeService
    {
        [OperationContract]
        void DoWork();
    }
}