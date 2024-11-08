using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;


namespace gaw241110.model
{
    public class CookieModel : ICookieModel,IGameClearCheckable
    {
        int _cookieNumber = 0;
        float _stackedCookieHeight = 0f;

        const float c_fakeCookieLength = .2f;


        public event Action CookieAdded;
        public event Action ClearedGame;

        public void AddCookie()
        {
            _cookieNumber++;
            _stackedCookieHeight = c_fakeCookieLength * _cookieNumber;

            Log.DebugAssert(CookieAdded != null);
            CookieAdded.Invoke();
            if(_stackedCookieHeight > GameConst.c_gameClearHeight)
            {
                ClearedGame?.Invoke();
            }
        }
    }
}