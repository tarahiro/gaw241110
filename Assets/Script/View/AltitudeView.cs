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
    public class AltitudeView:MonoBehaviour,IAltitudeView
    {
        [SerializeField] Slider _slider;
        [SerializeField] RectTransform _cat;

        private void Start()
        {
            _slider.maxValue = GameConst.c_gameClearHeight;
        }


        public void UpdateCatAltitude(float altitude)
        {
            Log.DebugLog("cat ;" + altitude);
            _cat.anchoredPosition = Vector2.up * GetComponent<RectTransform>().sizeDelta.y * altitude / _slider.maxValue;
        }
        public void UpdateSeaAltitude(float altitude)
        {
            Log.DebugLog("sea ;" + altitude);
            _slider.value = altitude;
        }
    }
}