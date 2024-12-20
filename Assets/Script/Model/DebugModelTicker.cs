using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using gaw241110.view;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;


namespace gaw241110.model
{
#if ENABLE_DEBUG
    public class DebugModelTicker : ITickable
    {

        [Inject] ICardManager cardManager;
        [Inject] MochiPresenter mochiPresenter;
        [Inject] CheckGamePresenter checkGamePresenter;
        [Inject] ISeaWarningView seaWarningView;
        [Inject] SeaModel seaModel;

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                cardManager.ShowCard();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                mochiPresenter.OnAddMochiClicker();
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                checkGamePresenter.OnGameClear();
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                seaWarningView.Show();
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                seaWarningView.End();
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                seaModel.WarningSeaState().Forget();
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                seaModel.SilentSeaState().Forget();
            }
        }
    }
#endif
}