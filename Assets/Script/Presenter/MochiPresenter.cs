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
    public class MochiPresenter: IInitializable
    {
        [Inject] IMochiMenuView _mochiMenuView;
        [Inject] IMochiModel _model;

        public void Initialize()
        {
            _model.StartModel(OnAddMochiClicker, OnFillTimeChanged);
        }

        public void OnAddMochiClicker()
        {
            _mochiMenuView.AddMochiClicker(OnClicked);
        }

        void OnClicked()
        {
            _model.AddStackedObj();
        }

        void OnFillTimeChanged(float time)
        {
            _mochiMenuView.SetFillTime(time);
        }
    }
}