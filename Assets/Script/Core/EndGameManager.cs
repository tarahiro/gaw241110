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
            //�K�v�ȗv�f���X�g�b�v������B�C�A�N���b�N��
            _seaTicker.InActivate();
            _cookiePresenter.StopCookie();

            //�Q�[���I�[�o�[��ʂ��Ăяo��

        }
    }
}