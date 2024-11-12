using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
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
        }
    }
#endif
}