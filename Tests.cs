using System;
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
    }
}