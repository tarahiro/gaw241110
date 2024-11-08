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
        [Inject] IConverterCookieToExp _converter;
        int _cookieNumber = 0;
        float _stackedCookieHeight = 0f;

        const float c_fakeCookieLength = .2f;


        public event Action CookieAdded;
        public event Action ClearedGame;

        public void AddCookie()
        {
            _cookieNumber++;
            _stackedCookieHeight = c_fakeCookieLength * _cookieNumber;

            CookieAdded?.Invoke();
            _converter.Convert(c_fakeCookieLength);



            if (_stackedCookieHeight > GameConst.c_gameClearHeight)
            {
                ClearedGame?.Invoke();
            }
        }
    }
}