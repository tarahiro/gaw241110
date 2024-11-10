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
        ICardView[] _viewList;
        List<ISkillViewArgs> _args;
        public event Action<string> CardSelected;

        [Inject]
        public void Construct()
        {
            _viewList = _cardRoot.GetComponentsInChildren<ICardView>();
        }


        void Start()
        {
            _cardRoot.SetActive(false);
        }

        public void Show(List<ISkillViewArgs> args)
        {
            _cardRoot.SetActive(true);

            _args = args;
            for (int i = 0; i < _viewList.Length; i++)
            {
                _viewList[i].Show(args[i]);
            }

        }

        public void Hide()
        {
            _cardRoot.SetActive(false);
        }

        public void OnClicked(int i)
        {
            CardSelected?.Invoke(_args[i].SkillId);
        }
    }
}