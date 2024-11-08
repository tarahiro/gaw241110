using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110
{
    public class EndGameManager : IInitializable
    {
        [Inject] IGameOverPresenter _presenter;

        [Inject] ISeaTicker _seaTicker;
        [Inject] ICookiePresenter _cookiePresenter;

        public void Initialize()
        {
            _presenter.GameOvered += GameOver;
        }

        void GameOver()
        {
            //必要な要素をストップさせる。海、クリック等
            _seaTicker.InActivate();
            _cookiePresenter.StopCookie();

            //ゲームオーバー画面を呼び出す

        }
    }
}