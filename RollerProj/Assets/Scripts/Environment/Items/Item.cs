using Roller.Environment.Items.Spawning;
using Roller.Environment.Track;
using UnityEngine;

namespace Roller.Environment.Items
{
    public abstract class Item : MonoBehaviour, IItem
    {
        public abstract IPositioningStrategy PositioningStrategy { get; }
        public bool IsActive => transform.parent.gameObject.activeSelf;


        public void Place(TrackPositionContext ctx)
        {
            transform.parent.position = PositioningStrategy.GetNextPosition(ctx);
        }

        public void Deactivate()
        {
            transform.parent.gameObject.SetActive(false);
        }

        public void Activate()
        {
            transform.parent.gameObject.SetActive(true);
        }
    }
}