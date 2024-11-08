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
        [SerializeField] Image _gaugeImage;
        [SerializeField] TextMeshProUGUI _currentLevel;
        [SerializeField] TextMeshProUGUI _nextLevel;
        const string c_levelPrefix = "Lv:";
        int m_maxGaugeValue;

        public void UpdateLevel(int nextLevel, int maxExp)
        {
            _currentLevel.text = c_levelPrefix + nextLevel.ToString();
            _nextLevel.text = c_levelPrefix + (nextLevel+1).ToString();
            m_maxGaugeValue = maxExp;
        }
        public void UpdateExp(int exp)
        {
            _gaugeImage.fillAmount = exp / (float)m_maxGaugeValue;
        }
    }
}