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

namespace gaw241110.presenter
{
    public class EndGamePresenter : IEndGamePresenter
    {
        [Inject] IEndGameViewContainer _viewSelector;

        IEndGameView _endGameView;
        
       public event Action RestartedGame;


        public void StartEndGame(string key)
        {
            _endGameView = _viewSelector.SelectView(key);

            _endGameView.Decided += OnDecide;

            _endGameView.AcceptInput();
            _endGameView.ShowView();
        }

        public void EndGameOver()
        {
            _endGameView.StopAcceptInput();
            _endGameView.EraseView();
            _endGameView.Decided -= OnDecide;
        }

        void OnDecide()
        {
            Log.DebugLog("リスタート");
            Log.DebugAssert(RestartedGame != null);
            RestartedGame?.Invoke();
        }
    }
}