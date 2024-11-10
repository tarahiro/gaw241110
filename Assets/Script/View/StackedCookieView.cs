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

        [SerializeField] float _cookieIntervalY = .2f;
        [SerializeField] float _cookieOffsetY = .1f;

        [SerializeField] GameObject _stackCookiePrefab;

        List<GameObject> _stackedCookieList = new List<GameObject>();

        float _cookieHeightSum = 0;

        public void StackCookie(ICookieViewArgs args)
        {
            _boardableOnCookie.BoardCookie(Vector3.up * (_cookieHeightSum + args.Length));

            var g = Instantiate(_stackCookiePrefab, transform);
            g.transform.localPosition = Vector3.up * (_cookieHeightSum + args.Length * .5f);
            _cookieHeightSum += args.Length;


        }
    }
}