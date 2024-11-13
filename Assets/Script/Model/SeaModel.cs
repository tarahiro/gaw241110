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
    public class SeaModel : ISeaModel, IPauseable
    {
        [Inject] ISeaParameter _parameter;
        float _seaAltitude = 0;
        Subject<float> _seaRisen = new Subject<float>();
        SeaState _seaState = SeaState.Normal;
        bool isPaused = false;

        enum SeaState
        {
            Normal,
            Warning,
            Silent
        }

        public float GetSeaAltitude => _seaAltitude;
        public IObservable<float> SeaRisen => _seaRisen;
        event Action _changedToWarning;
        event Action _changedToSilent;


        public void StartModel(Action<float> risen, Action seaLevelUpped, Action onWarning, Action onSilent)
        {
            _seaRisen.Subscribe(risen);
            _parameter.SeaLevelUpped += seaLevelUpped;
            _changedToWarning = onWarning;
            _changedToSilent = onSilent;
        }

        public void AddSea(float deltaTime)
        {
            float prevSeaAltitude = _seaAltitude;
            _seaAltitude += deltaTime * _parameter.GetSeaRiseSpeed * SpeedMultiplierForState();
            _seaRisen.OnNext(_seaAltitude);

            for (int i = 0; i < _parameter.GetWarningSeaAltitude.Length; i++)
            {
                if (prevSeaAltitude < _parameter.GetWarningSeaAltitude[i] &&
                    _seaAltitude >= _parameter.GetWarningSeaAltitude[i])
                {
                    WarningSeaState().Forget();
                }
            }
        }

        public async UniTask WarningSeaState()
        {
            float time = 0f;
            _seaState = SeaState.Warning;
            _changedToWarning.Invoke();
            await UniTask.WaitUntil(() => (time = PausableCounter(isPaused, time)) > _parameter.GetWarningSeaTime);
            SilentSeaState().Forget();

        }
        public async UniTask SilentSeaState()
        {
            float time = 0f;
            _seaState = SeaState.Silent;
            _changedToSilent.Invoke();
            await UniTask.WaitUntil(() => (time = PausableCounter(isPaused, time)) > _parameter.GetSilentSeaTime);
            _seaState = SeaState.Normal;

        }

        float SpeedMultiplierForState()
        {
            switch (_seaState)
            {
                case SeaState.Normal:
                    return 1f;

                case SeaState.Warning:
                    return _parameter.GetWarningSeaTime;

                case SeaState.Silent:
                    return _parameter.GetSilentSeaSpeedMultiplier;

                default:
                    return 0f;
            }
        }

        //Utility‰»‚µ‚½‚¢
        float PausableCounter(bool isPaused, float time)
        {
            if (!isPaused)
            {
                return time + Time.deltaTime;
            }
            else
            {
                return time;
            }
        }

        public void OnPause(PauseSignal signal)
        {
            isPaused = true;
        }
        public void OnResume(ResumeSignal signal)
        {
            isPaused = false;
        }
    }
}
