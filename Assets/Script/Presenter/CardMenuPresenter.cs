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
    public class CardMenuPresenter :ICardMenuPresenter,IInitializable
    {
        [Inject] ICardMenuView _view;

        public event Action CardSelected;

        public void Initialize()
        {
            _view.CardSelected += OnCardSelect;
        }

        public void Show()
        {
            _view.Show();
        }

        public void Hide()
        {
            _view.Hide();
        }

        void OnCardSelect()
        {
            CardSelected?.Invoke();
        }
    }
}