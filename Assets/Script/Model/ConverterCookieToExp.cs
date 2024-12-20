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
    public class ConverterCookieToExp : IExpGainer
    {
        [Inject] IExpModel _expModel;

        const float c_fakeConvertRate = 100f;

        public void GainExpFromCookie(float cookieLength)
        {
            _expModel.AddExp((int)(cookieLength * c_fakeConvertRate));
        }
        
    }
}