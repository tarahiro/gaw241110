using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241110
{
    public interface IEndGamePresenter
    {
        event Action RestartedGame;

        void StartEndGame(string key);

        void EndGameOver();
    }
}