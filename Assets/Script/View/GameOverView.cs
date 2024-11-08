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
    public class GameOverView : MonoBehaviour, IEndGameView
    {
        bool _isAcceptInput = false;
        [SerializeField] GameObject _description;

        public event Action Decided;

        void Start()
        {
            Hide();
        }

        public void Update()
        {
            if (_isAcceptInput)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Decided.Invoke();
                }
            }
            
        }

        public void Show()
        {
            _description.SetActive (true);
        }
        public void Hide()
        {
            _description.SetActive(false);
        }

        public void AcceptInput()
        {
            _isAcceptInput = true;
        }
        public void StopAcceptInput()
        {
            _isAcceptInput = false;
        }

    }
}