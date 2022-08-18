using System;

namespace LevelBuilder2d.Utilities
{
    public static class ValueToStepRounder
    {
        public static float RoundToStep(float value, float step)
            => value != 0 ? MathF.Round(value / step) * step : value;
    }
}
