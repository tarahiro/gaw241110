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
        #endregion



        public void Initialize()
        {
            _view.Clicked += OnClicked;
            _model.CookieAdded += OnCookieAdded;
        }


        void OnClicked()
        {
            _model.AddCookie();
        }

        void OnCookieAdded()
        {
            _stackedCookieView.StackCookie();
        }

        public void StopCookie()
        {
            _view.StopClickAccept();
        }
        public void StartCookie()
        {
            _view.AcceptClick();
        }

        //Fake
        public void OnPause(PauseSignal signal)
        {
            StopCookie();
        }
        public void OnResume(ResumeSignal signal)
        {
            StartCookie();
        }


    }
}
