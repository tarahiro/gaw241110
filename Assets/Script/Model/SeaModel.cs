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
    public class SeaModel: ISeaModel,IInitializable
    {
        float _seaAltitude = 0;
        float _seaRiseSpeed = .2f;
        int _seaLevel = 0;
        Subject<float> _seaRisen = new Subject<float>();

        const float _fakeSeaAltitudeForLevel = 2f;
        float _nextSeaLevelAltitude;

        public float GetSeaAltitude => _seaAltitude;
        public float GetSeaRiseSpeed => _seaRiseSpeed;
        public float GetNextSeaLevelAltitude => _nextSeaLevelAltitude;
        public IObservable<float> SeaRisen => _seaRisen;
        public event Action SeaLevelUpped;
        public void Initialize()
        {
            _nextSeaLevelAltitude = NextSeaLevelAltitude();
        }

        public void AddSea(float deltaTime)
        {
            _seaAltitude += deltaTime * SeaRiseSpeed();
            _seaRisen.OnNext(_seaAltitude);
        }

        public void SeaLevelUp()
        {
            _seaLevel++;
            _nextSeaLevelAltitude = NextSeaLevelAltitude();

            SeaLevelUpped.Invoke();
        }

        float SeaRiseSpeed()
        {
            return _seaLevel * _seaRiseSpeed;
        }

        //「ここを超えたら次のレベルになる」という高度
        // 1+2+3+4+...
        float NextSeaLevelAltitude()
        {
            return _fakeSeaAltitudeForLevel * (_seaLevel * (_seaLevel + 1) * .5f);
        }
    }
}