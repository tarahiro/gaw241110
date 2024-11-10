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
        [Inject] ICardModel _model;
        [Inject] IOfferedSkillViewArgsFactory _argsFactory;

        public event Action CardSelected;

        public void Initialize()
        {
            _view.CardSelected += OnCardSelect;
        }

        public void Show()
        {
            _view.Show(_argsFactory.Create());
        }

        public void Hide()
        {
            _view.Hide();
        }

        void OnCardSelect(string skillId)
        {
            _model.LearnSkill(skillId);
            CardSelected?.Invoke();
        }
    }
}