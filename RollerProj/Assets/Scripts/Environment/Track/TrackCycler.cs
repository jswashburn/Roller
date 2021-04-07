using UnityEngine;

namespace Roller.Environment.Track
{
    public class TrackCycler : MonoBehaviour
    {
        [SerializeField] Track[] trackPieces; // Track prefabs to choose from
        [SerializeField] Transform player;
        [SerializeField] float appearingGap;
        [SerializeField] float appearingDepth;

        TrackList _trackList;

        bool PlayerCrossedCyclePoint => player.transform.position.x >= _trackList.TriggerPoint.position.x;

        void Awake()
        {
            _trackList = new TrackList(appearingGap, appearingDepth, trackPieces);
        }

        void Update()
        {
            if (PlayerCrossedCyclePoint)
                _trackList.CycleTrack();
        }
    }
}
