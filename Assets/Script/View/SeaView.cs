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
    public class SeaView : MonoBehaviour, ISeaView, IGameOverCheckableView
    {
        [Inject] IGameOverableView _gameOverableView;

        [SerializeField] GameObject _sea;

        Vector3 _initialSeaPosition;


        public event Action GameOvered;


        void Start()
        {
            _initialSeaPosition = _sea.transform.position;
        }

        public void RiseSea(float seaLevel)
        {
            _sea.transform.position = _initialSeaPosition + seaLevel * Vector3.up;

            if(_sea.transform.position.y > _gameOverableView.GameOverableHeight)
            {
                Log.DebugAssert(GameOvered != null);
                GameOvered?.Invoke();
            }
        }
    }
}