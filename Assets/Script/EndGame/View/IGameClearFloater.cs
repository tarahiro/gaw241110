using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;
using gaw241110;
using gaw241110.endgame;
using gaw241110.endgame.presenter;

namespace gaw241110.endgame.view
{
    public interface IGameClearFloater
    {
        UniTask Float();
    }
}