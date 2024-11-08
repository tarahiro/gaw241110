using Cysharp.Threading.Tasks;
using gaw241110;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;
using gaw241110.endgame;

namespace gaw241110.endgame.presenter
{
    public interface IEndGameView : IAcceptableInput, IHideable
    {
    }
}