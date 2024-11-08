using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110
{
    public class GamePauser : IGamePauser
    {

        [Inject] ISeaTicker _seaTicker;
        [Inject] ICookiePresenter _cookiePresenter;

        public void Pause()
        {
            //必要な要素をストップさせる。海、クリック等
            _seaTicker.InActivate();
            _cookiePresenter.StopCookie();

        }

        public void Restart()
        {
            _seaTicker.Activate();
            _cookiePresenter.StartCookie();

        }
    }
}