using UnityEngine;

namespace Roller.Environment.Track
{
    public class TrackCycler : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] float minGap;
        [SerializeField] float gapVariation;
        [SerializeField] float heightVariation;

        TrackPool _trackPool;

        bool PlayerCrossedCyclePoint => player.transform.position.x >= _trackPool.CurrentTriggerPoint.position.x;

        void Awake()
        {
            TrackPiece[] trackPieces = GetComponentsInChildren<TrackPiece>(true);
            var chosenSpacingOptions = new SpacingOptions(minGap, gapVariation, heightVariation);

            _trackPool = new TrackPool(trackPieces, chosenSpacingOptions);
        }

        void Update()
        {
            if (_trackPool.ActiveCount >= 2 && PlayerCrossedCyclePoint)
                _trackPool.Cycle();
        }
    }
}