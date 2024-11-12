using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;
using gaw241110;
using gaw241110.endgame;
using gaw241110.endgame.presenter;

namespace gaw241110.endgame.view
{
    public class GameClearView : MonoBehaviour, IEndGameView
    {
        [Inject] IScreenFader _screenFader;
        [Inject] IGameClearFloater _gameClearFloater;

        bool _isAcceptInput = false;
        [SerializeField] GameObject _description;

        public event Action Decided;

        void Start()
        {
            Hide();
        }

        public void Update()
        {
            if (_isAcceptInput)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Decided.Invoke();
                }
            }
            
        }

        public void Show()
        {
            Enter().Forget();
        }

        async UniTask Enter()
        {
            await _gameClearFloater.Float();
            await _screenFader.FadeIn(1f);
            await UniTask.WaitForSeconds(1f);
            _description.SetActive(true);
            await _screenFader.FadeOut(1f);
            AcceptInput();
        }

        public void Hide()
        {
            _description.SetActive(false);
        }

        public void AcceptInput()
        {
            _isAcceptInput = true;
        }
        public void StopAcceptInput()
        {
            _isAcceptInput = false;
        }

    }
}