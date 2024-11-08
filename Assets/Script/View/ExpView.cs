using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;


namespace gaw241110.view
{
    public class ExpView :MonoBehaviour, IExpView
    {
        [SerializeField] Slider _slider;
        [SerializeField] TextMeshProUGUI _currentLevel;
        [SerializeField] TextMeshProUGUI _nextLevel;
        const string c_levelPrefix = "Lv:";

        public void UpdateLevel(int nextLevel, int maxExp)
        {
            _currentLevel.text = c_levelPrefix + nextLevel.ToString();
            _nextLevel.text = c_levelPrefix + (nextLevel+1).ToString();
            _slider.maxValue = maxExp;
        }
        public void UpdateExp(int exp)
        {
            _slider.value = exp;
        }
    }
}