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
using UnityEngine.UI;

namespace gaw241110.endgame.view
{
    public class GameClearView : MonoBehaviour, IEndGameView
    {
        [Inject] IScreenFader _screenFader;
        [Inject] IGameClearFloater _gameClearFloater;

        [SerializeField] GameObject _description;
        [SerializeField] GameObject _autoCamera;
        [SerializeField] Button _button;

        public event Action Decided;

        void Start()
        {
            Hide();
        }


        public void Show()
        {
            Enter().Forget();
        }

        async UniTask Enter()
        {
            _autoCamera.SetActive(false);
            await _gameClearFloater.Float();
            EndGameViewUtil.StopSounds();
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
            _button.interactable = true;
        }
        public void StopAcceptInput()
        {
            _button.interactable = false;
        }

        public void OnClick()
        {
            Decided.Invoke();
        }

    }
}