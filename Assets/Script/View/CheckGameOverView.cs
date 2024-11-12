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
    public class CheckGameOverView : MonoBehaviour,IGameOverCheckable, IPauseable
    {
        [Inject] ISeaView _seaView;
        [Inject] IGameOverableView _gameOverableView;

        [SerializeField] TextMeshProUGUI _countText;

        bool isTick = true;
        bool isCount = false;
        float _count = 0f;
        public event Action GameOvered;

        void Start()
        {
            _countText.gameObject.SetActive(false);
        }
        

        void Update()
        {
            if (isTick)
            {
                if (_seaView.GetSeaHeight > _gameOverableView.GameOverableHeight)
                {
                    if (!isCount)
                    {
                        isCount = true;
                        _countText.gameObject.SetActive(true);
                    }
                    else
                    {
                        _count += Time.deltaTime;
                        if (_count > GameConst.c_gameOverTime) GameOvered?.Invoke();
                        _countText.text = ((int)(GameConst.c_gameOverTime + 1f - _count)).ToString();
                    }

                }
                else
                {
                    if (isCount)
                    {
                        isCount = false;
                        _count = 0f;
                        _countText.gameObject.SetActive(false);
                    }
                }
            }
        }

        public void OnPause(PauseSignal signal)
        {
            isTick = false;
        }
        public void OnResume(ResumeSignal signal)
        {
            isTick = true;
        }
    }
}