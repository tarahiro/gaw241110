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
        [Inject] IExpGainer _expGainer;
        [Inject] ICookieParameter _parameter;
        [Inject] ICookieViewArgsFactory _viewArgsFactory;
        [Inject] ISeaModel _seaModel;

        int _cookieNumber = 0;
        float _stackedCookieHeight = 0f;

        Subject<float> _cookieAltitudeElevated = new Subject<float>();

        public event Action<ICookieViewArgs> _cookieAdded;
        public event Action ClearedGame;

        public IObservable<float> CookieAltitudeElevated => _cookieAltitudeElevated;

        public void InitializeModel(Action<ICookieViewArgs> cookieAdded, Action<float> cookieAltitudeElevated)
        {
            _cookieAdded += cookieAdded;
            _cookieAltitudeElevated.Subscribe(cookieAltitudeElevated);

            _cookieNumber = 0;
            _stackedCookieHeight = 0f;
            _cookieAltitudeElevated.OnNext(_stackedCookieHeight);
        }

        public void AddCookie()
        {
            //���g�̕ϐ��𐮗�
            var _addedCookieLength = _parameter.CookieLength * _parameter.AddedCookieNumber;
            _cookieNumber += _parameter.AddedCookieNumber;
            _stackedCookieHeight += _addedCookieLength;

            //�f���Q�[�g���s
            for (int i = 0; i < _parameter.AddedCookieNumber; i++)
            {
                _cookieAdded?.Invoke(_viewArgsFactory.Create(_parameter.CookieLength));
            }
            _cookieAltitudeElevated.OnNext(_stackedCookieHeight);

            //������
            //�o���l
            _expGainer.GainExpFromCookie(_addedCookieLength);
            //�C���x���m�F
            if(_stackedCookieHeight > _seaModel.GetNextSeaLevelAltitude)
            {
                _seaModel.SeaLevelUp();
            }
            if (_stackedCookieHeight > GameConst.c_gameClearHeight)
            {
                ClearedGame?.Invoke();
            }
        }
    }
}