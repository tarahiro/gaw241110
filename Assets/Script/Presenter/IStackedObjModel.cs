using Cysharp.Threading.Tasks;
using gaw241110;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;
using gaw241110.presenter;

namespace gaw241110.model
{
    public interface IStackedObjModel
    {
        //将来的にクッキーの種類を指定できるようにする
        void AddStackedObj(string prefabName, IStackedObjParameter parameter);
        IObservable<float> CookieAltitudeElevated { get; }
        void InitializeModel(Action<IStackedObjViewArgs> objAdded, Action<float> objAltitudeElevated);
    }
}