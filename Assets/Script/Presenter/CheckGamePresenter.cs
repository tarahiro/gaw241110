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
    public class CheckGamePresenter : ICheckGameOverPresenter,ICheckGameClearPresenter, IInitializable
    {
        [Inject] IGameManager _gameManager;
        [Inject] IGameOverCheckable _gameOverCheckable;
        [Inject] IGameClearCheckable _clearCheckable;

        public event Action GameOvered;
        public event Action GameCleared;

        public void Initialize()
        {
            _gameOverCheckable.GameOvered += OnGameOver;
            _clearCheckable.ClearedGame += OnGameClear;
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
    }
}