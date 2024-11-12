using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        [SerializeField] List<MochiView> _viewList = new List<MochiView>();

        void Start()
        {
            foreach (var view in _viewList)
            {
                view.gameObject.SetActive(false);
            }
        }

        public void AddMochiClicker(Action action)
        {
            var view = _viewList.First(x => !x.gameObject.activeSelf);
            view.gameObject.SetActive(true);
            view.Clicked += action;

            /*
            Transform t = Instantiate(Resources.Load<Transform>("MochiClicker"), transform);
            t.localPosition = _initialMochiRoot.localPosition + Vector3.right * _xOffset * _viewList.Count;

            _viewList.Add(t.GetComponent<IMochiView>());
            _viewList[_viewList.Count - 1].Clicked += action;
            */
        }
    }
}