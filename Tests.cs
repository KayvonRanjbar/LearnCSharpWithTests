using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LearnCSharpWithTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyArrayHas0Length()
        {
            var array = Array.Empty<string>();
            var arrayLength = array.Length;
            arrayLength.Should().Be(0);
        }

        [Test]
        public void DictionaryValues()
        {
            var dictionary = new Dictionary<string, string> {{"a", "alpha"}, {"b", "bravo"}};

            foreach (var dictionaryValue in dictionary.Values)
            {
                Console.WriteLine(dictionaryValue);
            }

            dictionary.Values.Should().BeOfType<Dictionary<string, string>.ValueCollection>();
        }

        [Test]
        public void LinqChaining()
        {
            List<string> names = new List<string> {"Joe", "Jane", "Jim"};
            IOrderedEnumerable<string> result = names.OrderBy(x => x.Length);
            result.Should().BeAssignableTo<IEnumerable<string>>();
        }

        [Test]
        public void LinqWhereMethodWithEmptyListDoesNotThrowException()
        {
            List<string> emptyList = new List<string>();
            foreach (var item in emptyList.Where(i => i.ToLower() == "randomString"))
            {
            }
        }

        [Test]
        public void ToLowerInvocationOnNullThrowsNullRefException()
        {
            string nullObject = null;
            Action toLowerAction = new Action(() => nullObject.ToLower());
            toLowerAction.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void ToLowerInvocationOnNullWithNullConditionalDoesNotThrowError()
        {
            string nullObject = null;
            nullObject?.ToLower();
        }

        [Test]
        public void ObjectsAreReferenceTypes()
        {
            var c1 = new Customer();
            c1.FirstName = "Bilbo";

            var c2 = c1;
            c2.FirstName = "Frodo";

            c1.FirstName.Should().Be("Frodo");
        }

        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        [Test]
        public void GetValueOrDefaultReturnsDefaultValueOfUnderlyingType()
        {
            // Arrange
            DateTime? nullableDateTime = null;

            // Act
            DateTime actual = nullableDateTime.GetValueOrDefault();

            // Assert
            DateTime expected = default; // DateTime.MinValue
            actual.Should().Be(expected);
        }
    }
}