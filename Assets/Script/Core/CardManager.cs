using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110
{
    public class CardManager : IInitializable
    {
        [Inject] ICheckCardPresenter _checkPresenter;
        [Inject] IGamePauser _gamePauser;


        public void Initialize()
        {
            _checkPresenter.ShowedCard += ShowCard;
        }

        void ShowCard()
        {
            Log.DebugLog("showCard");
            _gamePauser.Pause();
        }
    }
}