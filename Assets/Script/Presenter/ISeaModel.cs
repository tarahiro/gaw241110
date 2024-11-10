using Cysharp.Threading.Tasks;
using gaw241110;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter
{
    public interface ISeaModel
    {
        float GetSeaAltitude { get; }
        float GetSeaRiseSpeed { get; }
        float GetNextSeaLevelAltitude { get; }
        IObservable<float> SeaRisen { get; }
        event Action SeaLevelUpped;
        void AddSea(float deltaTime);
        void SeaLevelUp();
    }
}