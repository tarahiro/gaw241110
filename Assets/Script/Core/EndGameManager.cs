using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace gaw241110
{
    public class EndGameManager : IInitializable
    {
        [Inject] ICheckGameOverPresenter _checkGameOverPresenter;
        [Inject] ICheckGameClearPresenter _checkGameClearPresenter;
        [Inject] IGamePauser _gamePauser;

        [Inject] IEndGamePresenter _gameOverPresenter;

        public void Initialize()
        {
            _checkGameOverPresenter.GameOvered += GameOver;
            _checkGameClearPresenter.GameCleared += GameClear;
            _gameOverPresenter.RestartedGame += RestartGame;
        }

        void GameOver()
        {
            EndGame("GameOver");
        }

        void GameClear()
        {
            EndGame("GameClear");
        }

        void EndGame(string key)
        {
            _gamePauser.Pause();

            //ゲームオーバー画面を呼び出す
            _gameOverPresenter.StartEndGame(key);
        }

        void RestartGame()
        {
            Log.DebugLog("Restart");
            SceneManager.LoadScene("Main");
        }
    }
}