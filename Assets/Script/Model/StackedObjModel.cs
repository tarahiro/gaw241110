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
    public class StackedObjModel : IStackedObjModel,IGameClearCheckable
    {
        [Inject] IExpGainer _expGainer;
        [Inject] IStackedObjViewArgsFactory _viewArgsFactory;
        [Inject] ISeaModel _seaModel;
        [Inject] ISeaParameter _seaParameter;

        float _stackedCookieHeight = 0f;

        Subject<float> _cookieAltitudeElevated = new Subject<float>();

        public event Action<IStackedObjViewArgs> _objAdded;
        public event Action ClearedGame;

        public IObservable<float> CookieAltitudeElevated => _cookieAltitudeElevated;

        public void InitializeModel(Action<IStackedObjViewArgs> objAdded, Action<float> objAltitudeElevated)
        {
            _objAdded += objAdded;
            _cookieAltitudeElevated.Subscribe(objAltitudeElevated);

            _stackedCookieHeight = 0f;
            _cookieAltitudeElevated.OnNext(_stackedCookieHeight);
        }

        public void AddStackedObj(string prefabName, IStackedObjParameter parameter)
        {
            //自身の変数を整理
            _stackedCookieHeight += parameter.Length;

            //デリゲート実行
            _objAdded?.Invoke(_viewArgsFactory.Create(prefabName, parameter.Length, parameter.Scale));
            _cookieAltitudeElevated.OnNext(_stackedCookieHeight);

            //他処理
            //経験値
            _expGainer.GainExpFromCookie(parameter.Length);

            //海レベル確認
            if(_stackedCookieHeight > _seaParameter.GetNextSeaLevelAltitude)
            {
                _seaParameter.SeaLevelUp();
            }
            if (_stackedCookieHeight > GameConst.c_gameClearHeight)
            {
                ClearedGame?.Invoke();
            }
        }
    }
}