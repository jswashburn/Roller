using Roller.Environment.Track;
using Roller.Extensions.Unity;
using UnityEngine;

namespace Roller.Environment.Items.Spawning
{
    public class CoinPositioningStrategy : IPositioningStrategy
    {
        readonly float _spawnHeight;

        public CoinPositioningStrategy(float spawnHeight)
        {
            _spawnHeight = spawnHeight;
        }

        public Vector3 GetNextPosition(TrackPositionContext ctx)
        {
            return ctx.LastPosition.WithOffset(yOffset: _spawnHeight);
        }
    }
}