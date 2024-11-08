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
    public class GameClearView : MonoBehaviour, IEndGameView
    {
        bool _isAcceptInput = false;
        [SerializeField] GameObject _description;

        public event Action Decided;

        void Start()
        {
            EraseView();
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

        public void ShowView()
        {
            _description.SetActive (true);
        }
        public void EraseView()
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