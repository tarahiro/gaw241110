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
        const float _warningSeaSpeedMultiplier = 3f;
        const float _silentSeaSpeedMultiplier = .2f;
        const float _warningSeaTime = 3f;
        const float _silentSeaTime = 3f;

        readonly float[] _warningSeaAltitude = new float[2] { 80f, 150f };

        float _nextSeaLevelAltitude;
        float _seaRiseSpeed;
        public float GetNextSeaLevelAltitude => _nextSeaLevelAltitude;
        public float GetSeaRiseSpeed => _seaRiseSpeed;
        public float GetWarningSeaSpeedMultiplier => _warningSeaSpeedMultiplier;
        public float GetSilentSeaSpeedMultiplier => _silentSeaSpeedMultiplier;
        public float GetWarningSeaTime => _warningSeaTime;
        public float GetSilentSeaTime => _silentSeaTime;
        public float[] GetWarningSeaAltitude => _warningSeaAltitude;

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
            if (_seaLevel == 1)
            {
                SoundManager.PlayBGM("Main");
            }
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