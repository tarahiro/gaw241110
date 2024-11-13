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
    public class SeaPresenter : ISeaPresenter, IInitializable
    {
        [Inject] ISeaModel _model;
        [Inject] ISeaView _view;
        [Inject] IAltitudeUiView _alitudeView;
        [Inject] ISeaLevelUpView _levelUpView;
        [Inject] ISeaWarningView _warningView;

        public void Initialize()
        {
            _model.StartModel(OnRiseSea, OnSeaLevelUp,OnWarning,OnSilent);
        }
        public void StopSea()
        {

        }

        void OnRiseSea(float seaLevel)
        {
            _view.RiseSea(seaLevel);
            _alitudeView.UpdateSeaAltitude(seaLevel);
        }

        void OnSeaLevelUp()
        {
            _levelUpView.Show();
        }

        void OnWarning()
        {
            _warningView.Show();
        }

        void OnSilent()
        {
            _warningView.End();
        }

    }
}