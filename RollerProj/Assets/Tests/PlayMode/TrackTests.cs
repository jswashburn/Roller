using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Roller.Tests.PlayMode
{
    public class TrackTests
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TrackListCyclesAfterCrossingTriggerPoint()
        {
            var player = new GameObject();

            yield return null;
        }
    }
}