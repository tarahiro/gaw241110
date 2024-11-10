using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110
{
    public class CardManager : IInitializable, ICardManager
    {
        [Inject] ICheckCardMenuConditionPresenter _checkPresenter;
        [Inject] IGamePauser _gamePauser;
        [Inject] ICardMenuPresenter _cardMenuPresenter;


        public void Initialize()
        {
            _checkPresenter.FilledCondition += ShowCard;
            _cardMenuPresenter.CardSelected += OnSelectCard;
        }

        public void ShowCard()
        {
            _gamePauser.Pause();
            _cardMenuPresenter.Show();
        }

        void OnSelectCard()
        {
            _gamePauser.Restart();
            _cardMenuPresenter.Hide();
        }

    }
}