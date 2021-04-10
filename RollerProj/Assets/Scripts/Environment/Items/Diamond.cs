using Roller.Environment.Items.Spawning;
using UnityEngine;

namespace Roller.Environment.Items
{
    public class Diamond : Collectable
    {
        [SerializeField] float spawnHeight;
        public override IPositioningStrategy PositioningStrategy => new DiamondPositioningStrategy(spawnHeight);
        public override int Value => 100;
    }
}