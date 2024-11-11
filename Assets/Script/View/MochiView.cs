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

        public event Action Clicked;


        public void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            Log.DebugAssert(Clicked != null);
            Clicked.Invoke();
        }

        public void OnPause(PauseSignal signal)
        {
            StopClickAccept();
        }
        public void OnResume(ResumeSignal signal)
        {
            AcceptClick();
        }

        public void StopClickAccept()
        {
            _button.enabled = false;
        }
        public void AcceptClick()
        {
            _button.enabled = true;
        }
    }
}