using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Roller.Extensions;
using UnityEngine;

namespace Roller.Tests.EditMode
{
    public class LinkedListExtensionsTests
    {
        [Test]
        public void ForEachValue()
        {
            // ARRANGE
            LinkedList<string> stringList = new LinkedList<string>(new[]
            {
                "ONE", "TWO", "THREE"
            });

            // ACT
            var lowerCased = new List<string>();
            stringList.ForEachValue(s =>
            {
                lowerCased.Add(s.ToLower());
            });

            // ASSERT
            Assert.AreEqual("one", lowerCased[0]);
            Assert.AreEqual("two", lowerCased[1]);
            Assert.AreEqual("three", lowerCased[2]);
        }
    }
}
