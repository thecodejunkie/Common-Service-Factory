using System;
using System.ServiceModel;
using NUnit.Framework;

namespace CommonServiceFactory.Tests
{
    [TestFixture]
    public class when_creating_servicehost_using_servicehostfactory_with_valid_constructorstring
    {
        [Test]
        public void should_return_servicehost_instance()
        {
            var factory =
                new ServiceHostFactory();
            
            var host =
                factory.CreateServiceHost(typeof(FakeService).AssemblyQualifiedName, new[] { new Uri("net.tcp://localhost:8080") });

            host.ShouldBeOfType<ServiceHost>();
        }
    }

    [TestFixture]
    public class when_creating_servicehost_using_servicehostfactory_with_invalid_constructorstring
    {
        [Test]
        public void should_throw_serviceactivationexception()
        {
            var factory =
                new ServiceHostFactory();

            Exception exception =
                Catch.Exception(() => factory.CreateServiceHost(typeof(FakeService).FullName, new[] { new Uri("net.tcp://localhost:8080") }));

            exception.ShouldBeOfType<ServiceActivationException>();
        }
    }
}