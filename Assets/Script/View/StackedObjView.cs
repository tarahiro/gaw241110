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
    public class StackedObjView: MonoBehaviour, IStackedObjView
    {
        [Inject] IBoardable _boardable;

        float _heightSum = 0;

        public void StackCookie(IStackedObjViewArgs args)
        {
            _boardable.BoardCookie(Vector3.up * (_heightSum + args.Length));

            var g = Instantiate(Resources.Load<GameObject>(args.PrefabName), transform);
            g.transform.localPosition = Vector3.up * (_heightSum + args.Length * .5f);
            g.transform.localScale = g.transform.localScale * args.Scale;
            _heightSum += args.Length;


        }
    }
}