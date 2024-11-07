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

        [Inject]
        ICookieView _view;

        [Inject]
        ICookieModel _model;

        #endregion



        public void Initialize()
        {
            _view.Clicked += OnClicked;
        }


        public async UniTask Enter()
        {
            Log.DebugLog("CookiePresenterÇÃèàóùäJén");
        }

        void OnClicked()
        {
            _model.AddCookie();
        }

    }
}
