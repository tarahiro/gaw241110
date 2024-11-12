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
    public class CookieModel : ICookieModel
    {
        [Inject] ICookieParameter _parameter;
        [Inject] IStackedObjModel _stackedObjModel;

        public void AddStackedObj()
        {
            for (int i = 0; i < _parameter.AddedCookieNumber; i++)
            {
                _stackedObjModel.AddStackedObj("Cookie", _parameter);
            }
        }
    }
}