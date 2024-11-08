using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter
{
    public interface IEndGameViewContainer
    {
        IEndGameView SelectView(string key);
    }
}