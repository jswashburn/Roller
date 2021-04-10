using Roller.Environment.Items.Spawning;
using UnityEngine;

namespace Roller.Environment.Items
{
    public class Coin : Collectable
    {
        [SerializeField] float spawnHeight;

        public override IPositioningStrategy PositioningStrategy => new CoinPositioningStrategy(spawnHeight);
        public override int Value => 5;
    }
}