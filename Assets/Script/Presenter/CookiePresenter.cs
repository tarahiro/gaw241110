using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using Tarahiro;
using gaw241110;

namespace gaw241110.presenter
{
    public class CookiePresenter:ICookiePresenter, IInitializable
    {
        #region Field

        [Inject] ICookieView _view;

        [Inject] ICookieModel _model;

        [Inject] IStackedCookieView _stackedCookieView;
        #endregion



        public void Initialize()
        {
            _view.Clicked += OnClicked;
            _model.CookieAdded += OnCookieAdded;
        }


        public async UniTask Enter()
        {
            Log.DebugLog("CookiePresenterÇÃèàóùäJén");
        }

        void OnClicked()
        {
            _model.AddCookie();
        }

        void OnCookieAdded()
        {
            _stackedCookieView.StackCookie();
        }

    }
}
