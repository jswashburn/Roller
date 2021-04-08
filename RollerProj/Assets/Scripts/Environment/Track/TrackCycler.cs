using UnityEngine;

namespace Roller.Environment.Track
{
    public class TrackCycler : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] Transform trackStart;
        [SerializeField] float minGap;
        [SerializeField] float gapVariation;
        [SerializeField] float heightVariation;

        Track _track;

        bool PlayerCrossedCyclePoint => player.transform.position.x >= _track.CurrentTriggerPoint.position.x;
        float NextGap => minGap + Random.Range(0, gapVariation);
        float NextHeight => Random.Range(-heightVariation, heightVariation);

        void Awake()
        {
            TrackPiece[] trackPieces = GetComponentsInChildren<TrackPiece>(includeInactive: true);
            Vector3 initialPosition = trackStart.position;
            
            _track = new Track(trackPieces, initialPosition);
            _track.PositionAt(initialPosition, NextGap, NextHeight);
        }

        void Update()
        {
            if (PlayerCrossedCyclePoint)
                _track.CycleTrack(NextGap, NextHeight);
        }
    }
}
