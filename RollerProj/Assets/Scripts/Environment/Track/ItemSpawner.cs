using Roller.Extensions;
using Roller.Extensions.Unity;
using UnityEngine;

namespace Roller.Environment.Track
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] spawnableItems;
        [Range(0, 100)] [SerializeField] float spawnPercentage;
        [SerializeField] float spawnHeight;

        void OnEnable()
        {
            Track.OnCycle += MaybeSpawnItem;
        }

        void OnDisable()
        {
            Track.OnCycle -= MaybeSpawnItem;
        }

        public void MaybeSpawnItem(CycleContext ctx)
        {
            bool shouldSpawn = Random.Range(0, 100) < spawnPercentage;
            if (shouldSpawn)
            {
                GameObject randomItem = spawnableItems[spawnableItems.RandIdx()];

                float xMidpoint = (ctx.LastPosition.x - ctx.SecondPosition.x) / 2;
                Vector3 position = ctx.SecondPosition.WithOffset(xMidpoint, spawnHeight);
                Instantiate(randomItem, position, Quaternion.identity);
            }
        }
    }
}