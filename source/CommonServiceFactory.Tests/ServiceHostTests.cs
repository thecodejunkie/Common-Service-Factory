using System;
using System.ServiceModel;
using NUnit.Framework;

namespace CommonServiceFactory.Tests
{
    [TestFixture]
    public class when_creating_new_servicehost_with_valid_values_for_servicetype_and_baseaddresses
    {
        [Test]
        public void should_not_throw_argumentnullexception()
        {
            Exception exception =
                Catch.Exception(() => new CommonServiceFactory.ServiceHost(typeof(FakeService), new[] { new Uri("net.tcp://localhost:8080") }));

            exception.ShouldNotBeOfType<ArgumentNullException>();
        }

        [Test]
        public void should_persist_the_servicetype_value()
        {
            var host =
                new CommonServiceFactory.ServiceHost(typeof(FakeService), new[] { new Uri("net.tcp://localhost:8080") });

            host.ServiceType.ShouldBeOfType<FakeService>();
        }
    }

    [TestFixture]
    public class when_creating_new_servicehost_with_null_servicetype
    {
        [Test]
        public void should_throw_argumentnullexception()
        {
            typeof(ArgumentNullException).ShouldBeThrownBy(() =>
                new CommonServiceFactory.ServiceHost(null, new[] { new Uri("net.tcp://localhost:8080") }));
        }
    }

    [TestFixture]
    public class when_creating_new_servicehost_with_null_baseaddresses
    {
        [Test]
        public void should_throw_argumentnullexception()
        {
            Exception exception =
                Catch.Exception(() =>new ServiceHost(typeof(FakeService), null));

            exception.ShouldBeOfType<ArgumentNullException>();
        }
    }

    [TestFixture]
    public class when_opening_the_servicehost
    {
        [Test]
        public void should_add_the_servicebehavior_to_the_behavior_collection()
        {
            var host = 
                new ServiceHost(typeof(FakeService), new[] { new Uri("net.tcp://localhost:8081") });
            host.AddServiceEndpoint(typeof(IFakeService), new NetTcpBinding(), "net.tcp://localhost:8081/MyService");
            host.Open();

            host.Description.Behaviors.ShouldContainType<ServiceBehavior>();
            host.Close();
        }
    }
}