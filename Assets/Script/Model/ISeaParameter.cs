using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;


namespace gaw241110.model
{
    public interface ISeaParameter
    {
        float GetNextSeaLevelAltitude { get; }
        float GetSeaRiseSpeed { get; }

        float GetWarningSeaSpeedMultiplier { get; }
        float GetSilentSeaSpeedMultiplier { get; }
        float GetWarningSeaTime { get; }
        float GetSilentSeaTime { get; }

        float[] GetWarningSeaAltitude { get; }

        event Action SeaLevelUpped;
        void SeaLevelUp();

        void MultiplySeaRiseSpeed(float coeff);
    }
}