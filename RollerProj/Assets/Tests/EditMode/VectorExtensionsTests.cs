using NUnit.Framework;
using Roller.Extensions;
using UnityEngine;

namespace Roller.Tests.EditMode
{
    public class VectorExtensionsTests
    {
        [Test]
        public void With()
        {
            // ARRANGE
            Vector3 position = new Vector3(10, 10, 10);
            Vector3 newPosition = position.With(11);
            
            // ASSERT
            Assert.AreEqual(11, newPosition.x);
            Assert.AreEqual(10, newPosition.y);
            Assert.AreEqual(10, newPosition.z);
        }

        [Test]
        public void WithOffset()
        {
            // ARRANGE
            Vector3 position = new Vector3(0, 0, 0);
            Vector3 newPosition = position.WithOffset(5);
            newPosition = newPosition.WithOffset(5, 2, 2);
            
            // ASSERT
            Assert.AreEqual(10, newPosition.x);
            Assert.AreEqual(2, newPosition.y);
            Assert.AreEqual(2, newPosition.z);
        }
    }
}
