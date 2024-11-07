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
    public class GameOverPresenter : IInitializable
    {

        [Inject] IGameOverCheckableView _view;

        public void Initialize()
        {
            _view.GameOvered += OnGameOver;
        }

        void OnGameOver()
        {
            Log.DebugLog("GameOver");
        }
    }
}