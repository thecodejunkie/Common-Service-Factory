using CommonServiceFactory.Conventions;
using NUnit.Framework;

namespace CommonServiceFactory.Tests
{
    [TestFixture]
    public class when_getting_service_contract_name_from_default_connections
    {
        [Test]
        public void should_prefix_service_type_name_with_i()
        {
            var serviceContractName =
                string.Concat("I", typeof(FakeService).Name);

            var conventions =
                new DefaultConventions();

            var conventionContractName =
                conventions.GetServiceContractName(typeof(FakeService));

            serviceContractName.ShouldEqual(conventionContractName);
        }
    }
}