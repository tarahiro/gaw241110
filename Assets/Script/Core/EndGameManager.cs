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
        [Inject] ICheckGameOverPresenter _checkGameOverPresenter;

        [Inject] ISeaTicker _seaTicker;
        [Inject] ICookiePresenter _cookiePresenter;

        [Inject] IGameOverPresenter _gameOverPresenter;

        public void Initialize()
        {
            _checkGameOverPresenter.GameOvered += GameOver;
            _gameOverPresenter.RestartedGame += RestartGame;
        }

        void GameOver()
        {
            //�K�v�ȗv�f���X�g�b�v������B�C�A�N���b�N��
            _seaTicker.InActivate();
            _cookiePresenter.StopCookie();

            //�Q�[���I�[�o�[��ʂ��Ăяo��
            _gameOverPresenter.StartGameOver();
        }

        void RestartGame()
        {
            Log.DebugLog("Restart");
        }
    }
}