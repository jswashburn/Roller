using System.Collections.Generic;
using System.Linq;

namespace Roller.Environment.Items.Pooling
{
    public class CollectablePool : Pool<Collectable>
    {
        void Awake()
        {
            Collectable[] initial = GetComponentsInChildren<Collectable>(true);

            Active = new Queue<Collectable>(initial
                .Where(item => item.IsActive).ToList());

            Inactive = new Queue<Collectable>(initial
                .Where(item => !item.IsActive).ToList());
        }
    }
}