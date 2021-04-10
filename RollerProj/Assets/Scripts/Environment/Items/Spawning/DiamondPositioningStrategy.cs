using Roller.Environment.Track;
using Roller.Extensions.Unity;
using UnityEngine;

namespace Roller.Environment.Items.Spawning
{
    public class DiamondPositioningStrategy : IPositioningStrategy
    {
        readonly float _spawnHeight;

        public DiamondPositioningStrategy(float spawnHeight)
        {
            _spawnHeight = spawnHeight;
        }

        public Vector3 GetNextPosition(TrackPositionContext ctx)
        {
            float xMidpoint = (ctx.LastPosition.x - ctx.SecondPosition.x) / 2;

            return ctx.SecondPosition.WithOffset(xMidpoint, _spawnHeight);
        }
    }
}