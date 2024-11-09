using Cysharp.Threading.Tasks;
using gaw241110;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;
using gaw241110.endgame;

namespace gaw241110.endgame.presenter
{
    public class EndGamePresenter : IEndGamePresenter
    {
        [Inject] IEndGameViewProvider _viewSelector;

        IEndGameView _endGameView;
        
       public event Action RestartedGame;


        public void StartEndGame(string key)
        {
            _endGameView = _viewSelector.SelectView(key);

            _endGameView.Decided += OnDecide;

            _endGameView.AcceptInput();
            _endGameView.Show();
        }

        public void EndGameOver()
        {
            _endGameView.StopAcceptInput();
            _endGameView.Hide();
            _endGameView.Decided -= OnDecide;
        }

        void OnDecide()
        {
            Log.DebugAssert(RestartedGame != null);
            RestartedGame?.Invoke();
        }
    }
}