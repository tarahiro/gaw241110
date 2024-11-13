using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tarahiro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace gaw241110.view
{
    public class MochiView : MonoBehaviour, IMochiView
    {
        [SerializeField] Button _button;
        [SerializeField] Image _imageGuage;
        [SerializeField] GameObject[] _effect;
        float _time = 0f;
        bool _isCountTime = false;
        float _fillTime;

        public event Action Clicked;


        void Start()
        {
            _button.onClick.AddListener(OnClick);
            StopClickAccept();
            foreach (var effect in _effect)
            {
                effect.SetActive(false);
            }
        }

        private void OnEnable()
        {
            _isCountTime = true;
        }

        void Update()
        {
            if (_isCountTime && !_button.interactable)
            {
                _time += Time.deltaTime;
                UpdateImageGauge();
            }
        }

        public void OnClick()
        {
            Log.DebugAssert(Clicked != null);
            Clicked.Invoke();
            SoundManager.PlaySE("Click");

            _time = 0f;
            StopClickAccept();
        }

        public void OnPause(PauseSignal signal)
        {
            Log.DebugLog("Pause: "+gameObject.name);
            StopClickAccept();
            _isCountTime = false;
        }
        public void OnResume(ResumeSignal signal)
        {
            Log.DebugLog("Resume: " + gameObject.name);
            AcceptClick();
        }

        public void StopClickAccept()
        {
            _button.interactable = false;
            foreach (var effect in _effect)
            {
                effect.SetActive(false);
            }
        }

        public void AcceptClick()
        {
            _isCountTime = true;
            if(_time > _fillTime)
            {
                _button.interactable = true;
                foreach (var effect in _effect)
                {
                    effect.SetActive(true);
                }
            }
        }

        public void SetFillTime(float time)
        {
            _fillTime = time;
            UpdateImageGauge();
        }

        void UpdateImageGauge()
        {
            _imageGuage.fillAmount = _time / _fillTime;
            if (_time > _fillTime)
            {
                _button.interactable = true;
                AcceptClick();
            }

        }
    }
}