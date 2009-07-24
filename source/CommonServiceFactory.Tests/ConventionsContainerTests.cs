using System;
using CommonServiceFactory.Conventions;
using NUnit.Framework;

namespace CommonServiceFactory.Tests
{
    [TestFixture]
    public class when_retrieving_conventions_with_null_service_type
    {
        [Test]
        public void should_throw_argumentnullexception()
        {
            var container =
                new ConventionsContainer();

            var exception =
                Catch.Exception(() => container.Get(null));

            exception.ShouldBeOfType(typeof(ArgumentNullException));
        }
    }

    [TestFixture]
    public class when_retrieving_conventions_for_registered_type
    {
        [Test]
        public void should_return_conventions()
        {
            var container =
                new ConventionsContainer();

            container.Setup(c => c.Use<FakeConventions>().For<FakeService>());

            var conventions =
                container.Get(typeof(FakeService));

            conventions.ShouldBeOfType(typeof(FakeConventions));
        }
    }
}