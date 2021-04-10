using System;
using System.Collections.Generic;
using System.Linq;
using Roller.Extensions;
using Roller.Extensions.Unity;
using UnityEngine;

namespace Roller.Environment.Track
{
    public class TrackPool
    {
        readonly LinkedList<TrackPiece> _active;
        readonly List<TrackPiece> _inactive;
        readonly SpacingOptions _spacingOptions;

        public TrackPool(TrackPiece[] initialTracks, SpacingOptions spacingOptions)
        {
            _active = new LinkedList<TrackPiece>(initialTracks
                .Where(piece => piece.IsActive).ToList());

            _inactive = new List<TrackPiece>(initialTracks
                .Where(piece => !piece.IsActive));

            _spacingOptions = spacingOptions;
            _active.PositionEach(_spacingOptions);
        }

        TrackPiece First => _active.First.Value;
        TrackPiece Second => _active.First.Next?.Value;
        TrackPiece Last => _active.Last.Value;
        Vector3 LastTrackPosition => Last.transform.position;

        public Transform CurrentTriggerPoint => Second.cycleTrigger;
        public int ActiveCount => _active.Count;
        public static event Action<TrackPositionContext> OnTrackCycle;

        public void Cycle()
        {
            Deactivate(First);

            TrackPiece next = _inactive.PopRandom();
            AddNextTrack(next);
            _active.Cycle(next);

            SendCycleMessage();
        }

        void SendCycleMessage()
        {
            var cycleContext = new TrackPositionContext
            {
                FirstPosition = First.transform.position,
                SecondPosition = Second.transform.position,
                LastPosition = Last.transform.position
            };

            OnTrackCycle?.Invoke(cycleContext);
        }

        void AddNextTrack(TrackPiece trackPiece)
        {
            trackPiece.Activate();
            trackPiece.AppearAt(LastTrackPosition.WithOffset(
                _spacingOptions.NextGap,
                _spacingOptions.NextHeight));
        }

        void Deactivate(TrackPiece trackPiece)
        {
            _inactive.Add(trackPiece);
            trackPiece.DeActivate();
        }

        public override string ToString()
        {
            string activeTracks = $"Active tracks:\t{_active.Stringify()}";
            string inactiveTracks = $"Despawned tracks:\t{_inactive.Stringify()}";
            return $"{activeTracks}\n{inactiveTracks}";
        }
    }
}