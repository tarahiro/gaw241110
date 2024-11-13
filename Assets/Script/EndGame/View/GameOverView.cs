using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;
using gaw241110;
using gaw241110.endgame;
using gaw241110.endgame.presenter;
using UnityEngine.UI;

namespace gaw241110.endgame.view
{
    public class GameOverView : MonoBehaviour, IEndGameView
    {
        [SerializeField] GameObject _description;
        [SerializeField] Button _button;

        public event Action Decided;

        void Start()
        {
            Hide();
        }


        public void Show()
        {
            _description.SetActive (true);
            AcceptInput();
        }
        public void Hide()
        {
            _description.SetActive(false);
        }

        public void AcceptInput()
        {
            _button.interactable = true;
        }
        public void StopAcceptInput()
        {
            _button.interactable = false;
        }

        public void OnClick()
        {
            EndGameViewUtil.StopSounds();
            Decided.Invoke();

        }

    }
}