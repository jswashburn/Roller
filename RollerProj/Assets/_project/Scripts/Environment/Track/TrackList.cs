using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackList
{
    float _appearingGap;
    float _appearingDepth;
    LinkedList<Track> _track;
    List<Track> _despawned;

    Track First => _track.First.Value;
    Track Second => _track.First.Next.Value;
    Vector3 LastTrackPosition => _track.Last.Value.transform.position;

    public Transform TriggerPoint => Second.cycleTrigger;

    public TrackList(float appearingGap, float appearingDepth, Track[] initialTracks)
    {
        _appearingGap = appearingGap;
        _appearingDepth = appearingDepth;

        _track = new LinkedList<Track>(initialTracks
            .Where(track => track.gameObject.activeSelf).ToList());
        _despawned = new List<Track>(initialTracks
            .Where(track => !track.gameObject.activeSelf).ToList());
    }

    public void CycleTrack()
    {
        Track newTrack = GetNewTrackPiece();

        MakeTrackDisappear(First);
        MakeTrackAppear(newTrack);

        _track.Cycle(newTrack);
    }

    void MakeTrackAppear(Track trackPiece)
    {
        trackPiece.Activate();
        trackPiece.AppearAt(LastTrackPosition
            .WithOffset(xOffset: _appearingGap, yOffset: _appearingDepth));
    }

    void MakeTrackDisappear(Track trackPiece)
    {
        _despawned.Add(trackPiece);
        trackPiece.DeActivate();
    }

    Track GetNewTrackPiece()
    {
        Track newTrackPiece = _despawned.Pop<Track>(Random.Range(0, _despawned.Count - 1));
        return newTrackPiece;
    }

    public override string ToString()
    {
        string activeTracks = $"Active tracks:\t{_track.Stringify()}";
        string despawnedTracks = $"Despawned tracks:\t{_despawned.Stringify()}";
        return $"{activeTracks}\n{despawnedTracks}";
    }
}
