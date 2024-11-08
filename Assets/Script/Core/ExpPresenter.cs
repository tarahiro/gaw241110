using Cysharp.Threading.Tasks;
using gaw241110;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter
{
    public class ExpPresenter:IInitializable
    {
        [Inject] IExpModel _model;
        [Inject] IExpView _view;

        public void Initialize()
        {
            _model.InitializeModel(OnUpdateExp, OnUpdateLevel);
        }

        void OnUpdateLevel(int nextLevel)
        {
            _view.UpdateLevel(nextLevel,_model.GetMaxExp);
        }

        void OnUpdateExp(int addExp)
        {
            _view.UpdateExp(addExp);
        }
    }
}