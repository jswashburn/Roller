using System.Collections.Generic;
using Roller.Environment.Items.Pooling;
using Roller.Environment.Track;
using UnityEngine;

namespace Roller.Environment.Items.Spawning
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] List<CollectablePool> collectablePools;

        void OnEnable()
        {
            TrackPool.OnTrackCycle += MaybeSpawnItem;
        }

        void OnDisable()
        {
            TrackPool.OnTrackCycle -= MaybeSpawnItem;
        }

        void MaybeSpawnItem(TrackPositionContext ctx)
        {
            foreach (CollectablePool pool in collectablePools)
            {
                bool shouldSpawn = Random.Range(0, 100) < pool.spawnPercentage;

                if (shouldSpawn)
                {
                    Collectable item = pool.Get();
                    if (item != null)
                        item.Place(ctx);
                }
            }
        }
    }
}