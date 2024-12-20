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
    public class MochiModel : IMochiModel
    {
        [Inject] IMochiParameter _parameter;
        [Inject] IStackedObjModel _stackedObjModel;

        public void StartModel(Action act, Action<float> timeAct)
        {
            _parameter.StartModel(act, timeAct);
        }

        public void AddStackedObj()
        {
            _stackedObjModel.AddStackedObj("Mochi", _parameter);
        }
    }
}