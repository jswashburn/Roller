using System.Collections.Generic;
using System.Linq;
using Roller.Extensions;
using UnityEngine;

namespace Roller.Environment.Track
{
    public class Track
    {
        readonly LinkedList<TrackPiece> _trackLinkedList;
        readonly List<TrackPiece> _inactiveTracks;

        TrackPiece First => _trackLinkedList.First.Value;
        TrackPiece Second => _trackLinkedList.First.Next.Value;
        Vector3 LastTrackPosition => _trackLinkedList.Last.Value.transform.position;

        public Transform CurrentTriggerPoint => Second.cycleTrigger;

        public Track(TrackPiece[] initialTracks, Vector3 initialPosition)
        {
            _trackLinkedList = new LinkedList<TrackPiece>(initialTracks
                .Where(track => track.IsActive).ToList());
            
            _inactiveTracks = new List<TrackPiece>(initialTracks
                .Where(track => !track.IsActive).ToList());
        }
        
        public void PositionAt(Vector3 position, float gap, float heightOffset)
        {
            Vector3 nextPosition = position;
            _trackLinkedList.ForEachValue(trackPiece =>
            {
                if (trackPiece.gameObject.activeSelf)
                    trackPiece.AppearAt(nextPosition);
                nextPosition = nextPosition.WithOffset(
                    xOffset: gap,
                    yOffset: heightOffset);
            });
        }

        public void CycleTrack(float gap, float heightOffset)
        {
            TrackPiece newTrackPiece = GetNewTrackPiece();

            MakeTrackDisappear(First);
            MakeTrackAppear(newTrackPiece, gap, heightOffset);

            _trackLinkedList.Cycle(newTrackPiece);
        }

        void MakeTrackAppear(TrackPiece trackPiece, float gap, float heightOffset)
        {
            trackPiece.Activate();
            trackPiece.AppearAt(LastTrackPosition.WithOffset(
                xOffset: gap,
                yOffset: heightOffset));
        }

        void MakeTrackDisappear(TrackPiece trackPiece)
        {
            _inactiveTracks.Add(trackPiece);
            trackPiece.DeActivate();
        }

        TrackPiece GetNewTrackPiece()
        {
            TrackPiece newTrackPiece = _inactiveTracks.Pop(Random.Range(0, _inactiveTracks.Count - 1));
            return newTrackPiece;
        }

        public override string ToString()
        {
            string activeTracks = $"Active tracks:\t{_trackLinkedList.Stringify()}";
            string inactiveTracks = $"Despawned tracks:\t{_inactiveTracks.Stringify()}";
            return $"{activeTracks}\n{inactiveTracks}";
        }
    }
}
