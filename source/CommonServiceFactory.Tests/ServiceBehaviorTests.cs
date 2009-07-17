using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using NUnit.Framework;

namespace CommonServiceFactory.Tests
{
    [TestFixture]
    public class when_creating_servicebehavior_with_null_servicetype
    {
        [Test]
        public void should_throw_argumentnullexception()
        {
            Exception exception =
                Catch.Exception(() => new ServiceBehavior(null));

            exception.ShouldBeOfType<ArgumentNullException>();
        }
    }

    [TestFixture]
    public class when_creating_servicebehavior_with_valid_servicetype
    {
        [Test]
        public void should_persist_servicetype_to_servicetype_property()
        {
            var behavior =
                new ServiceBehavior(typeof(FakeService));

            behavior.ServiceType.ShouldBeOfType<FakeService>();
        }
    }

    [TestFixture]
    public class when_applying_dispatch_behavior
    {
        [Test]
        public void should_set_instanceprovider_to_endpointdispatchers_of_matching_contracts()
        {
            var host =
                new ServiceHost(typeof(FakeService), new[] { new Uri("net.tcp://localhost:8082") });

            host.AddServiceEndpoint(typeof(IFakeServiceContract), new NetTcpBinding(), "net.tcp://localhost:8082/MyService");
            host.Open();

            var matchingDispatchers = 
                from d in host.ChannelDispatchers
                where ((ChannelDispatcher)d).Endpoints.Any(e => 
                    (e.DispatchRuntime.InstanceProvider != null) ? e.DispatchRuntime.InstanceProvider.GetType() == typeof(ServiceInstanceProvider) : false)
                select d;

            matchingDispatchers.Count().ShouldEqual(1);

            host.Close();
        }
    }
}