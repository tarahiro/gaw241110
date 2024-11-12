using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.model;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;


namespace gaw241110.view
{
    public class SeaModel: ISeaModel
    {
        [Inject] ISeaParameter _parameter;
        float _seaAltitude = 0;
        Subject<float> _seaRisen = new Subject<float>();

        public float GetSeaAltitude => _seaAltitude;
        public IObservable<float> SeaRisen => _seaRisen;


        public void StartModel(Action<float> risen,Action seaLevelUpped)
        {
            _seaRisen.Subscribe(risen);
            _parameter.SeaLevelUpped += seaLevelUpped;
        }

        public void AddSea(float deltaTime)
        {
            _seaAltitude += deltaTime * _parameter.GetSeaRiseSpeed;
            _seaRisen.OnNext(_seaAltitude);
        }
    }
}