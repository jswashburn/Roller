using Roller.Environment.Track;
using UnityEngine;

namespace Roller.Environment.Items.Spawning
{
    // Different items will have different ways of placing themselves relative to the track
    // hence the strategy pattern

    public interface IPositioningStrategy
    {
        Vector3 GetNextPosition(TrackPositionContext trackPositionContext);
    }
}