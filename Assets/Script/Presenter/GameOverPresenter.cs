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
    public class GameOverPresenter : IGameOverPresenter, IInitializable
    {
        [Inject] IGameManager _gameManager;
        [Inject] IGameOverCheckableView _view;

        public event Action GameOvered;

        public void Initialize()
        {
            _view.GameOvered += OnGameOver;
        }

        void OnGameOver()
        {
            Log.DebugLog("GameOver");
            Log.DebugAssert(GameOvered != null);
            GameOvered?.Invoke();
        }
    }
}