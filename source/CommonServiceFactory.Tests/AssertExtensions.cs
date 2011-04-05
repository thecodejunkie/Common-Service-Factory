using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;

namespace CommonServiceFactory.Tests
{
    public static class AssertExtensions
    {
        public static void ShouldContainType<T>(this IList collection)
        {
            var selection =
                from c in collection.Cast<object>()
                where c.GetType().IsAssignableFrom(typeof(T))
                select c;

            Assert.IsTrue(selection.Count() > 0);
        }

        public static void ShouldEqual(this object actual, object expected)
        {
            Assert.AreEqual(actual, expected);
        }

        public static void ShouldBeOfType<T>(this Type asserted)
        {
            Assert.IsTrue(asserted == typeof(T));
        }

        public static void ShouldBeOfType<T>(this object asserted)
        {
            asserted.ShouldBeOfType(typeof(T));
        }

        public static void ShouldBeOfType(this object asserted, Type expected)
        {
            Assert.IsInstanceOf(expected, asserted);
        }

        public static void ShouldNotBeOfType<T>(this object assertedType)
        {
            if (assertedType != null)
            {
                Assert.IsNotInstanceOf(typeof(T), assertedType);
            }
        }

        public static void ShouldBeThrownBy(this Type expectedType, Action context)
        {
            Exception exception = null;

            try
            {
                context();
            }
            catch (Exception thrownException)
            {
                exception = thrownException;
                Assert.AreEqual(expectedType, thrownException.GetType());
            }

            if (exception == null)
            {
                Assert.Fail(string.Format("Expected exception of type '{0}'", expectedType.FullName));
            }
        }
    }
}
