using UnityEngine;

namespace Roller.Environment.Track
{
    public class SpacingOptions
    {
        readonly float _gapVariation;
        readonly float _heightVariation;
        readonly float _minSpacing;

        public SpacingOptions(float minSpacing, float gapVariation, float heightVariation)
        {
            _minSpacing = minSpacing;
            _gapVariation = gapVariation;
            _heightVariation = heightVariation;
        }

        public float NextGap => _minSpacing + Random.Range(0, _gapVariation);
        public float NextHeight => Random.Range(-_heightVariation, _heightVariation);
    }
}