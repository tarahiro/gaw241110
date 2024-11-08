using Cysharp.Threading.Tasks;
using gaw241110;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter
{
    public interface IExpModel
    {
        void AddExp(int addedExp);
        IObservable<int> ExpUpdated { get; }
        IObservable<int> LevelUpped { get; }
        void InitializeModel(Action<int> expUpdated, Action<int> levelUpped);
        int GetMaxExp { get; }
    }
}