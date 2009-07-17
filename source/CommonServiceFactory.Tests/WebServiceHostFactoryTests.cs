using System;
using System.ServiceModel;
using NUnit.Framework;

namespace CommonServiceFactory.Tests
{
    [TestFixture]
    public class when_creating_servicehost_using_webservicehostfactory_with_valid_constructorstring
    {
        [Test]
        public void should_return_webservicehost_instance()
        {
            var factory =
                new WebServiceHostFactory();

            var host =
                factory.CreateServiceHost(typeof(FakeService).AssemblyQualifiedName, new[] { new Uri("net.tcp://localhost:8080") });

            host.ShouldBeOfType<WebServiceHost>();
        }
    }

    [TestFixture]
    public class when_creating_servicehost_using_webservicehostfactory_with_invalid_constructorstring
    {
        [Test]
        public void should_throw_serviceactivationexception()
        {
            var factory =
                new WebServiceHostFactory();

            Exception exception =
                Catch.Exception(() => factory.CreateServiceHost(typeof(FakeService).FullName, new[] { new Uri("net.tcp://localhost:8080") }));

            exception.ShouldBeOfType<ServiceActivationException>();
        }
    }
}