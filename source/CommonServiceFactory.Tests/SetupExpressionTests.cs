using System;
using CommonServiceFactory.Conventions;
using NUnit.Framework;

namespace CommonServiceFactory.Tests
{
    [TestFixture]
    public class when_retrieving_conventions_for_unregistered_type
    {
        [Test]
        public void should_return_default_conventions()
        {
            var expression =
                new SetupExpression();

            expression.Get(typeof(FakeService)).ShouldBeOfType(typeof(DefaultConventions));
        }
    }

    [TestFixture]
    public class when_registering_new_conventions_as_default
    {
        [Test]
        public void should_return_new_default_conventions_for_unregistered_type()
        {
            var expression =
                new SetupExpression();

            expression.Use<FakeConventions>().AsDefault();

            var conventions =
                expression.Get(typeof(FakeService));

            conventions.ShouldBeOfType(typeof(FakeConventions));
        }
    }

    [TestFixture]
    public class when_retriving_conventions_for_null_service_type
    {
        [Test]
        public void should_throw_argumentnullexception()
        {
            var expression =
                new SetupExpression();

            var exception =
                Catch.Exception(() => expression.Get(null));

            exception.ShouldBeOfType(typeof(ArgumentNullException));

        }
    }

    [TestFixture]
    public class when_registering_conventions_using_lambda
    {
        [Test]
        public void should_return_conventions_when_retrived()
        {
            var expression =
                new SetupExpression();

            expression.Use(() => new FakeConventions()).For<FakeService>();

            var conventions =
                expression.Get(typeof(FakeService));

            conventions.ShouldBeOfType(typeof(FakeConventions));
        }
    }

    [TestFixture]
    public class when_retriving_conventions_for_registered_type
    {
        [Test]
        public void should_return_registered_conventions()
        {
            var expression =
                new SetupExpression();

            expression.Use<FakeConventions>().For<FakeService>();

            var conventions =
                expression.Get(typeof(FakeService));

            conventions.ShouldBeOfType(typeof(FakeConventions));
        }
    }
}