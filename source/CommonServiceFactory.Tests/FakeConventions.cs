using System;
using CommonServiceFactory.Conventions;

namespace CommonServiceFactory.Tests
{
    public class FakeConventions : IConventions
    {
        public string GetServiceContractName(Type serviceType)
        {
            return string.Concat("IContract", serviceType.Name);
        }
    }
}