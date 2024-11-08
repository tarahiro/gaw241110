using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110
{
    public class GamePauser : IGamePauser,IInitializable
    {
        [Inject] private SignalBus _signalBus;

        private bool _isPause = false;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_isPause)
                {
                    // PauseEventを発行する
                    _signalBus.Fire<PauseSignal>();
                }
                else
                {
                    _signalBus.Fire<ResumeSignal>();
                }
                _isPause = !_isPause;
            }
        }

        // [Inject] ISeaTicker _seaTicker;
        // [Inject] ICookiePresenter _cookiePresenter;

        public void Initialize()
        {
            _signalBus.Fire<PauseSignal>();
            _signalBus.Fire<ResumeSignal>();
        }

        public void Pause()
        {
            _signalBus.Fire<PauseSignal>();
            /*
            //必要な要素をストップさせる。海、クリック等
            _seaTicker.InActivate();
            _cookiePresenter.StopCookie();
            */
        }

        public void Restart()
        {
            _signalBus.Fire<ResumeSignal>();
            /*
            _seaTicker.Activate();
            _cookiePresenter.StartCookie();
            */
        }
    }
}