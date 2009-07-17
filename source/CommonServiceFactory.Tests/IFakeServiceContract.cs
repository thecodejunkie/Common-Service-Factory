using System.ServiceModel;

namespace CommonServiceFactory.Tests
{
    [ServiceContract]
    public interface IFakeServiceContract
    {
        [OperationContract]
        void DoWork();
    }
}