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
    public class SeaWarningView :MonoBehaviour, ISeaWarningView
    {
        [Inject] IWarningFader _warningFader;
        [SerializeField] GameObject _gameObject;

        void Start()
        {
            _gameObject.SetActive(false);
        }


        public void Show()
        {
            _warningFader.Warning().Forget();
            SoundManager.PlaySEWithLoop("Warning");
            _gameObject.SetActive(true);
        }

        public void End()
        {
            _warningFader.EndWarning();
            SoundManager.StopLoopSE();
            _gameObject.SetActive(false);
        }
    }
}