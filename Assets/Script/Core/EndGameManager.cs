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

        [Inject] ISeaTicker _seaTicker;
        [Inject] ICookiePresenter _cookiePresenter;

        [Inject] IEndGamePresenter _gameOverPresenter;

        public void Initialize()
        {
            _checkGameOverPresenter.GameOvered += GameOver;
            _checkGameClearPresenter.GameCleared += GameClear;
            _gameOverPresenter.RestartedGame += RestartGame;
        }

        void GameOver()
        {
            //必要な要素をストップさせる。海、クリック等
            _seaTicker.InActivate();
            _cookiePresenter.StopCookie();

            //ゲームオーバー画面を呼び出す
            _gameOverPresenter.StartEndGame("GameOver");
        }
        void GameClear()
        {
            //必要な要素をストップさせる。海、クリック等
            _seaTicker.InActivate();
            _cookiePresenter.StopCookie();

            //ゲームオーバー画面を呼び出す
            _gameOverPresenter.StartEndGame("GameClear");
        }

        void RestartGame()
        {
            Log.DebugLog("Restart");
            SceneManager.LoadScene("Main");
        }
    }
}