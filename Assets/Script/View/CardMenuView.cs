using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;


namespace gaw241110.view
{
    public class CardMenuView:MonoBehaviour,ICardMenuView
    {
        [SerializeField] GameObject _cardRoot;
        public event Action CardSelected;

        void Start()
        {
            _cardRoot.SetActive(false);
        }

        public void Show(List<ISkillViewArgs> args)
        {
            _cardRoot.SetActive(true);

        }

        public void Hide()
        {
            _cardRoot.SetActive(false);
        }

        public void OnClicked()
        {
            CardSelected?.Invoke();
        }
    }
}