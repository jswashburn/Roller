using UnityEngine;

namespace Roller.Environment.Track
{
    public class TrackCycler : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] Transform trackStart;
        [SerializeField] float appearingGap;

        Track _track;

        bool PlayerCrossedCyclePoint => player.transform.position.x >= _track.CurrentTriggerPoint.position.x;

        void Awake()
        {
            TrackPiece[] trackPieces = GetComponentsInChildren<TrackPiece>(includeInactive: true);
            Vector3 initialPosition = trackStart.position;
            
            _track = new Track(trackPieces, initialPosition);
            _track.PositionAt(initialPosition, appearingGap);
        }

        void Update()
        {
            if (PlayerCrossedCyclePoint)
                _track.CycleTrack(appearingGap);
        }
    }
}
