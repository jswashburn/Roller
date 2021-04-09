using System;
using System.Collections.Generic;
using System.Linq;
using Roller.Extensions;
using Roller.Extensions.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Roller.Environment.Track
{
    public class CycleContext
    {
        public Vector3 FirstPosition { get; set; }
        public Vector3 SecondPosition { get; set; }
        public Vector3 LastPosition { get; set; }
    }

    public class Track
    {
        readonly List<TrackPiece> _inactiveTracks;
        readonly LinkedList<TrackPiece> _trackLinkedList;

        public Track(TrackPiece[] initialTracks, Vector3 initialPosition)
        {
            _trackLinkedList = new LinkedList<TrackPiece>(initialTracks
                .Where(track => track.IsActive).ToList());

            _inactiveTracks = new List<TrackPiece>(initialTracks
                .Where(track => !track.IsActive).ToList());
        }

        TrackPiece First => _trackLinkedList.First.Value;
        TrackPiece Second => _trackLinkedList.First.Next.Value;
        TrackPiece Last => _trackLinkedList.Last.Value;
        Vector3 LastTrackPosition => Last.transform.position;

        public Transform CurrentTriggerPoint => Second.cycleTrigger;

        public static event Action<CycleContext> OnCycle;

        public void PositionAt(Vector3 position, float gap, float heightOffset)
        {
            Vector3 nextPosition = position;
            _trackLinkedList.ForEachValue(trackPiece =>
            {
                if (trackPiece.gameObject.activeSelf)
                    trackPiece.AppearAt(nextPosition);
                nextPosition = nextPosition.WithOffset(
                    gap,
                    heightOffset);
            });
        }

        public void CycleTrack(float gap, float heightOffset)
        {
            TrackPiece newTrackPiece = GetNewTrackPiece();

            MakeTrackDisappear(First);
            MakeTrackAppear(newTrackPiece, gap, heightOffset);

            _trackLinkedList.Cycle(newTrackPiece);

            var cycleContext = new CycleContext
            {
                FirstPosition = First.transform.position,
                SecondPosition = Second.transform.position,
                LastPosition = Last.transform.position
            };

            OnCycle?.Invoke(cycleContext);
        }

        void MakeTrackAppear(TrackPiece trackPiece, float gap, float heightOffset)
        {
            trackPiece.Activate();
            trackPiece.AppearAt(LastTrackPosition.WithOffset(
                gap,
                heightOffset));
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