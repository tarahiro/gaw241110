using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
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
        Subject<float> _cookieAltitudeElevated = new Subject<float>();


        public event Action CookieAdded;
        public event Action ClearedGame;
        public IObservable<float> CookieAltitudeElevated => _cookieAltitudeElevated;

        public void InitializeModel(Action cookieAdded, Action<float> cookieAltitudeElevated)
        {
            CookieAdded += cookieAdded;
            _cookieAltitudeElevated.Subscribe(cookieAltitudeElevated);

            _cookieNumber = 0;
            _stackedCookieHeight = 0f;
            _cookieAltitudeElevated.OnNext(_stackedCookieHeight);
        }

        public void AddCookie()
        {
            _cookieNumber++;
            _stackedCookieHeight = c_fakeCookieLength * _cookieNumber;

            CookieAdded?.Invoke();
            _cookieAltitudeElevated.OnNext(_stackedCookieHeight);
            _converter.Convert(c_fakeCookieLength);


            if (_stackedCookieHeight > GameConst.c_gameClearHeight)
            {
                ClearedGame?.Invoke();
            }
        }
    }
}