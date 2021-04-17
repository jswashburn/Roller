using Roller.Environment.Items.Spawning;
using UnityEngine;

namespace Roller.Environment.Items
{
    public class Diamond : Collectable
    {
        [SerializeField] float spawnHeight;
        [SerializeField] string pickupSound;
        public override IPositioningStrategy PositioningStrategy => new DiamondPositioningStrategy(spawnHeight);
        public override string PickupSound => pickupSound;
        public override int Value => 100;
    }
}