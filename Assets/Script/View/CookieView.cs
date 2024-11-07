using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;


namespace gaw241110.view
{
    public class CookieView : MonoBehaviour, ICookieView
    {
        public event Action Clicked;

        public void OnClick()
        {
            Log.DebugAssert(Clicked != null);
            Clicked.Invoke();
        }
    }
}