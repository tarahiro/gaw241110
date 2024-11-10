using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.model;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter
{
    public class StackedObjPresenter:IInitializable
    {
        [Inject] IStackedObjModel _model;

        [Inject] IStackedObjView _stackedCookieView;

        [Inject] IAltitudeUiView _altitudeView;

        public void Initialize()
        {
            _model.InitializeModel(OnCookieAdded, OnCookieAltitudeElevated);
        }

        void OnCookieAdded(IStackedObjViewArgs args)
        {
            _stackedCookieView.StackCookie(args);
        }

        void OnCookieAltitudeElevated(float altitude)
        {
            _altitudeView.UpdateBoarderAltitude(altitude);
        }

    }
}