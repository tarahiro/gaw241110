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
            //�K�v�ȗv�f���X�g�b�v������B�C�A�N���b�N��
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