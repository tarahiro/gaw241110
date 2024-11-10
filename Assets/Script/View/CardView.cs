using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace gaw241110.view
{
    public class CardView : MonoBehaviour,ICardView
    {
        ISkillViewArgs _args;

        [SerializeField] TextMeshProUGUI _title;
        [SerializeField] TextMeshProUGUI _description;

        public void Show(ISkillViewArgs args)
        {
            _args = args;
            _title.text = _args.DisplayName;
            _description.text = _args.Description;
        }

        void Start()
        {
        }

    }
}