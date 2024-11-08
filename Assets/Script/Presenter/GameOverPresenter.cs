using Cysharp.Threading.Tasks;
using gaw241110;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter
{
    public class GameOverPresenter : IGameOverPresenter, IInitializable
    {
        [Inject] IGameOverView _gameOverView;

       public event Action RestartedGame;

        public void Initialize() {
            _gameOverView.Decided += OnDecide;
        }

        public void StartGameOver()
        {
            _gameOverView.AcceptInput();
        }

        void OnDecide()
        {
            Log.DebugAssert(RestartedGame != null);
            RestartedGame?.Invoke();
        }
    }
}