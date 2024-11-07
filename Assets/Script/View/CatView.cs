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
    public class CatView:MonoBehaviour,IBoardableOnCookie, IGameOverableView
    {
        [SerializeField] Transform _gameOverHorizon;

        public void BoardCookie(Vector3 localPosition)
        {
            transform.localPosition = localPosition;
        }
        public float GameOverableHeight => _gameOverHorizon.position.y;
    }
}