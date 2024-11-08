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
        float GetSeaLevel { get; }
        float GetSeaRiseSpeed { get; }
        IObservable<float> SeaRisen { get; }

        void AddSea(float addedSeaLevel);
    }
}