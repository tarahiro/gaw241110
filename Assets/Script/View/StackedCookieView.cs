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
    public class StackedCookieView: MonoBehaviour, IStackedCookieView
    {
        [Inject] IBoardableOnCookie _boardableOnCookie;

        float _cookieHeightSum = 0;

        public void StackCookie(ICookieViewArgs args)
        {
            _boardableOnCookie.BoardCookie(Vector3.up * (_cookieHeightSum + args.Length));

            var g = Instantiate(Resources.Load<GameObject>(args.PrefabName), transform);
            g.transform.localPosition = Vector3.up * (_cookieHeightSum + args.Length * .5f);
            g.transform.localScale = g.transform.localScale * args.Scale;
            _cookieHeightSum += args.Length;


        }
    }
}