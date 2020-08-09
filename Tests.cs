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
    }
}