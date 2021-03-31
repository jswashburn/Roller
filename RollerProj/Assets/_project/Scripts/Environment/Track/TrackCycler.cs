using UnityEngine;
using System.Collections.Generic;

public class TrackCycler : MonoBehaviour
{
    [SerializeField] Track[] prefabs; // Track prefabs to choose from
    [SerializeField] Transform player;
    [SerializeField] float travelDistanceBeforeNextCycle;
    [SerializeField] float appearingOffsetX;
    [SerializeField] float appearingSpawnDepth;

    LinkedList<Track> _track; // The active track pieces
    List<Track> _despawned; // Deactivated track pieces
    Track _first;
    Track _last;

    void Awake()
    {
        _track = new LinkedList<Track>(prefabs);
        _despawned = new List<Track>();
    }

    void Update()
    {
        _first = _track.First.Value;
        _last = _track.First.Value;
    }

    void OnTriggerEnter(Collider other)
    {
        // First -> Go away and enter available tracks pool
        // Last -> Grab a random track from available tracks pool and tell it to appear
        // Cycler -> Update the linked list and move trigger collider

        // Move cycle trigger collider right
        transform.position = transform.position.WithOffset(xOffset: travelDistanceBeforeNextCycle);
        CycleTrack();
    }

    void CycleTrack()
    {
        // So we know where to put the appearing track
        Vector3 end = _last.transform.position;

        // New track that is now list.last will position itself and animate upwards
        _last.Appear(end.WithOffset(xOffset: appearingOffsetX, yOffset: appearingSpawnDepth));

        // Animate downwards, will deactivate from animation event
        _first.Disappear();
        _despawned.Add(_first);

        CycleTrackList();
    }

    void CycleTrackList()
    {
        _track.RemoveFirst();
        _track.AddLast(_despawned.Pop<Track>(Random.Range(0, _despawned.Count)));
    }
}
