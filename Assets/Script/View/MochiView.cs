using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
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
        float _time = 0f;
        bool _isCountTime = false;
        float _fillTime;

        public event Action Clicked;


        void Start()
        {
            _button.onClick.AddListener(OnClick);
            StopClickAccept();
        }

        private void OnEnable()
        {
            _isCountTime = true;
        }

        void Update()
        {
            if (_isCountTime && !_button.enabled)
            {
                _time += Time.deltaTime;
                UpdateImageGauge();
            }
        }

        public void OnClick()
        {
            Log.DebugAssert(Clicked != null);
            Clicked.Invoke();

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
            _button.enabled = false;
        }

        public void AcceptClick()
        {
            _isCountTime = true;
            if(_time > _fillTime)
            {
                _button.enabled = true;
            }
        }

        public void SetFillTime(float time)
        {
            _fillTime = time;
            UpdateImageGauge();
            Log.DebugLog(_fillTime.ToString());
        }

        void UpdateImageGauge()
        {
            _imageGuage.fillAmount = _time / _fillTime;
            if (_time > _fillTime)
            {
                _button.enabled = true;
                AcceptClick();
            }

        }
    }
}