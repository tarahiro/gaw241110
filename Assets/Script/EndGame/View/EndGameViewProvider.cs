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
    public class EndGameViewProvider : IEndGameViewProvider
    {
        [Inject] GameOverView _gameOverView;
        [Inject] GameClearView _gameClearView;

        public IEndGameView SelectView(string key)
        {

            switch (key)
            {
                case "GameOver":
                    return _gameOverView;

                case "GameClear":
                    return _gameClearView;

                default:
                    Log.DebugAssert("keyÇ™ïsê≥Ç≈Ç∑");
                    return null;
            }
        }
    }
}