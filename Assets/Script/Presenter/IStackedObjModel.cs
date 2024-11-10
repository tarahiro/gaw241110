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
        //�����I�ɃN�b�L�[�̎�ނ��w��ł���悤�ɂ���
        void AddStackedObj(string prefabName, IStackedObjParameter parameter);
        IObservable<float> CookieAltitudeElevated { get; }
        void InitializeModel(Action<IStackedObjViewArgs> objAdded, Action<float> objAltitudeElevated);
    }
}