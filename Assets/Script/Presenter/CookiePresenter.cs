using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using Tarahiro;
using gaw241110;
using System;

namespace gaw241110.presenter
{
    public class CookiePresenter:ICookiePresenter, IInitializable
    {
        #region Field

        [Inject] IClickCookieView _view;

        [Inject] ICookieModel _model;

        [Inject] IStackedCookieView _stackedCookieView;

        [Inject] IAltitudeView _altitudeView;
        #endregion



        public void Initialize()
        {
            _view.Clicked += OnClicked;
            _model.InitializeModel(OnCookieAdded, OnCookieAltitudeElevated);
        }


        void OnClicked()
        {
            _model.AddCookie();
        }

        void OnCookieAdded()
        {
            _stackedCookieView.StackCookie();
        }

        void OnCookieAltitudeElevated(float altitude)
        {
            _altitudeView.UpdateCatAltitude(altitude);
        }


        public void OnPause(PauseSignal signal)
        {
            _view.StopClickAccept();
        }
        public void OnResume(ResumeSignal signal)
        {
            _view.AcceptClick();
        }


    }
}
