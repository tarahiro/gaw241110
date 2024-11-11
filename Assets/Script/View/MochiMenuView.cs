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
    public class MochiMenuView : MonoBehaviour, IMochiMenuView
    {
        [SerializeField] Transform _initialMochiRoot;
        [SerializeField] float _xOffset = 200f;

        List<IMochiView> _viewList = new List<IMochiView>();

        void Start()
        {

        }

        public void AddMochiClicker(Action action)
        {
            Transform t = Instantiate(Resources.Load<Transform>("MochiClicker"), transform);
            t.localPosition = _initialMochiRoot.localPosition + Vector3.right * _xOffset * _viewList.Count;

            _viewList.Add(t.GetComponent<IMochiView>());
            _viewList[_viewList.Count - 1].Clicked += action;
        }
    }
}