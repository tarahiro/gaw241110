using Cysharp.Threading.Tasks;
using gaw241110;
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
        float _seaLevel = 0;
        float _seaRiseSpeed = .1f;
        Subject<float> _risenSea = new Subject<float>();

        public float GetSeaLevel => _seaLevel;
        public float GetSeaRiseSpeed => _seaRiseSpeed;
        public IObservable<float> RisenSea => _risenSea;

        public void AddSea(float addedSeaLevel)
        {
            _seaLevel += addedSeaLevel;
            _risenSea.OnNext(_seaLevel);
        }
    }
}