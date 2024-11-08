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
    public class GameOverView : IGameOverView, ITickable
    {
        bool _isAcceptInput = false;

        public event Action Decided;

        public void Tick()
        {
            if (_isAcceptInput)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Decided.Invoke();
                }
            }
            
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