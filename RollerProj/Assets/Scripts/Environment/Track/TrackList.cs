using System.Collections.Generic;
using System.Linq;
using Roller.Extensions;
using UnityEngine;

namespace Roller.Environment.Track
{
    public class TrackList
    {
        readonly float _appearingGap;
        readonly float _appearingDepth;
        readonly LinkedList<Track> _track;
        readonly List<Track> _inactiveTracks;

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
            _inactiveTracks = new List<Track>(initialTracks
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
            _inactiveTracks.Add(trackPiece);
            trackPiece.DeActivate();
        }

        Track GetNewTrackPiece()
        {
            Track newTrackPiece = _inactiveTracks.Pop<Track>(Random.Range(0, _inactiveTracks.Count - 1));
            return newTrackPiece;
        }

        public override string ToString()
        {
            string activeTracks = $"Active tracks:\t{_track.Stringify()}";
            string inactiveTracks = $"Despawned tracks:\t{_inactiveTracks.Stringify()}";
            return $"{activeTracks}\n{inactiveTracks}";
        }
    }
}
