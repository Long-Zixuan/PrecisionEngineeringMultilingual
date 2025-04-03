using UnityEngine;
using PrecisionEngineering.Data.Language;

namespace PrecisionEngineering.Data
{
    internal class AngleMeasurement : Measurement
    {
        public AngleMeasurement(float size, Vector3 position, Vector3 normal, MeasurementFlags flags)
            : base(position, flags)
        {
            AngleSize = size;
            AngleNormal = normal;
        }

        /// <summary>
        /// Size of the angle in degrees
        /// </summary>
        public float AngleSize { get; }

        /// <summary>
        /// Direction vector with the angle normal (ie the "middle" of the angle)
        /// </summary>
        public Vector3 AngleNormal { get; }

        public override string ToString()
        {
            return
                string.Format(Language.Language.Instance.trans("Angle")+": {0}бу, @{1}," + Language.Language.Instance.trans("facing") + ": {2}\n\t{3}", AngleSize, Position, AngleNormal, Flags);
        }
    }
}
