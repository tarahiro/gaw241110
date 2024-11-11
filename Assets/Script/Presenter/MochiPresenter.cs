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
    public class MochiPresenter
    {
        [Inject] IMochiMenuView _mochiMenuView;

        public void AddMochiMenuView()
        {
            _mochiMenuView.AddMochiClicker(OnClicked);
        }

        void OnClicked()
        {
            Log.DebugLog("MochiClicked");
        }
    }
}