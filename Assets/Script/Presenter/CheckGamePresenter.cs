using Cysharp.Threading.Tasks;
using gaw241110.view;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter

{
    public class CheckGamePresenter : ICheckGameOverPresenter,ICheckGameClearPresenter, ICheckCardMenuConditionPresenter, IInitializable
    {
        [Inject] IGameManager _gameManager;
        [Inject] IGameOverCheckable _gameOverCheckable;
        [Inject] IGameClearCheckable _clearCheckable;
        [Inject] IShowCardConditionCheckable _showCardCheckable;

        public event Action GameOvered;
        public event Action GameCleared;
        public event Action FilledCondition;

        public void Initialize()
        {
            _gameOverCheckable.GameOvered += OnGameOver;
            _clearCheckable.ClearedGame += OnGameClear;
            _showCardCheckable.ShowCardChecked += OnFilledCondition;
        }

        void OnGameOver()
        {
            Log.DebugLog("GameOver");
            Log.DebugAssert(GameOvered != null);
            GameOvered?.Invoke();
        }

        void OnGameClear()
        {
            GameCleared?.Invoke();
        }

        void OnFilledCondition()
        {
            FilledCondition?.Invoke();
        }
    }
}