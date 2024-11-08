using Cysharp.Threading.Tasks;
using gaw241110;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter
{
    public interface ICookieModel
    {
        //将来的にクッキーの種類を指定できるようにする
        void AddCookie();
        event Action CookieAdded;
        IObservable<float> CookieAltitudeElevated { get; }
        void InitializeModel(Action cookieAdded, Action<float> cookieAltitudeElevated);
    }
}