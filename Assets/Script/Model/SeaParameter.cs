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
    public class SeaParameter: ISeaParameter,IInitializable
    {
        float _initialSeaRiseSpeed = .4f;
        int _seaLevel = 0;
        float _seaSpeedMultiplyer = 1f;

        const float _fakeSeaAltitudeForLevel = 2f;
        float _nextSeaLevelAltitude;
        float _seaRiseSpeed;
        public float GetNextSeaLevelAltitude => _nextSeaLevelAltitude;
        public float GetSeaRiseSpeed => _seaRiseSpeed;

        public event Action SeaLevelUpped;

        public void Initialize()
        {
            _nextSeaLevelAltitude = NextSeaLevelAltitude();
        }

        public void SeaLevelUp()
        {
            _seaLevel++;
            _nextSeaLevelAltitude = NextSeaLevelAltitude();
            UpdateSeaRiseSpeed();
            SeaLevelUpped.Invoke();
        }

        public void MultiplySeaRiseSpeed(float coeff)
        {
            _seaSpeedMultiplyer = coeff;
            UpdateSeaRiseSpeed();
        }


        //「ここを超えたら次のレベルになる」という高度
        // 1+2+3+4+...
        float NextSeaLevelAltitude()
        {
            return _fakeSeaAltitudeForLevel * (_seaLevel * (_seaLevel + 1) * .5f);
        }

        void UpdateSeaRiseSpeed()
        {
            _seaRiseSpeed = _seaLevel * _initialSeaRiseSpeed * _seaSpeedMultiplyer;
            Log.DebugLog(_seaRiseSpeed.ToString());

        }
    }
}