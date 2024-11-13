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
        IObservable<float> SeaRisen { get; }
        void AddSea(float deltaTime);
        void StartModel(Action<float> risen, Action levelUpped,Action onWarning, Action onSilent);
    }
}