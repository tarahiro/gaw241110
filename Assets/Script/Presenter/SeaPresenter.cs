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
    public class SeaPresenter : IInitializable
    {
        [Inject] ISeaModel _model;
        [Inject] ISeaView _view;

        public void Initialize()
        {
            _model.RisenSea.Subscribe(OnRiseSea);
        }

        void OnRiseSea(float seaLevel)
        {
            _view.RiseSea(seaLevel);
        }
    }
}