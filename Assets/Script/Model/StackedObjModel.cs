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
        [Inject] ICookieParameter _parameter;
        [Inject] IStackedObjViewArgsFactory _viewArgsFactory;
        [Inject] ISeaModel _seaModel;

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
            //���g�̕ϐ��𐮗�
            _stackedCookieHeight += _parameter.Length;

            //�f���Q�[�g���s
            _objAdded?.Invoke(_viewArgsFactory.Create(prefabName, _parameter.Length, _parameter.Scale));
            _cookieAltitudeElevated.OnNext(_stackedCookieHeight);

            //������
            //�o���l
            _expGainer.GainExpFromCookie(_parameter.Length);

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