using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;
using gaw241110;
using gaw241110.endgame;

namespace gaw241110.endgame.presenter
{
    public interface IEndGameViewContainer
    {
        IEndGameView SelectView(string key);
    }
}