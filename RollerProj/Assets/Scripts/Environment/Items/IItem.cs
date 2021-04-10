using Roller.Environment.Items.Pooling;
using Roller.Environment.Items.Spawning;
using Roller.Environment.Track;

namespace Roller.Environment.Items
{
    public interface IItem : IPoolable
    {
        IPositioningStrategy PositioningStrategy { get; }
        void Place(TrackPositionContext ctx);
    }
}