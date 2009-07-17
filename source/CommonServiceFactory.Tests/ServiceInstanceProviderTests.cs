using System;
using Microsoft.Practices.ServiceLocation;
using Moq;
using NUnit.Framework;

namespace CommonServiceFactory.Tests
{
    [TestFixture]
    public class when_creating_serviceinstanceprovider_with_null_as_servicetype
    {
        [Test]
        public void should_throw_argumentnullexception()
        {
            Exception exception =
                Catch.Exception(() => new ServiceInstanceProvider(null));

            exception.ShouldBeOfType<ArgumentNullException>();
        }
    }

    [TestFixture]
    public class when_creating_serviceinstanceprovider_with_valid_servicetype
    {
        [Test]
        public void should_persist_value_to_servicetype_property()
        {
            var instanceProvider =
                new ServiceInstanceProvider(typeof(FakeService));

            instanceProvider.ServiceType.ShouldBeOfType<FakeService>();
        }
    }

    [TestFixture]
    public class when_getting_instance
    {
        [Test]
        public void foo()
        {
            var mock = new Mock<IServiceLocator>();
            mock.Setup(m => m.GetInstance(typeof(FakeService))).Returns(new FakeService());

            ServiceLocator.SetLocatorProvider(() => mock.Object);

            var instanceProvider =
                new ServiceInstanceProvider(typeof(FakeService));

            instanceProvider.GetInstance(null).ShouldBeOfType<FakeService>();
        }
    }
}