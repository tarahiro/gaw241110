using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;


namespace gaw241110.model
{
    public class CookieParameter : ICookieParameter
    {
        const int c_InitialAddedCookieNumber = 1;
        const float c_InitialCookieLength = .2f;

        int _addedCookieNumber = c_InitialAddedCookieNumber;
        float _cookieLength = c_InitialCookieLength;



        public int AddedCookieNumber => _addedCookieNumber;
        public float CookieLength => _cookieLength;

        public float CookieScale { get; set; } = 1f;

        public void MultiplyAddedCookieNumber(int multiplierFromInit)
        {
            _addedCookieNumber = c_InitialAddedCookieNumber * multiplierFromInit;
        }

        public void MultiplyCookieLength(float multiplierFromInit)
        {
            _cookieLength = c_InitialCookieLength * multiplierFromInit;
            CookieScale = multiplierFromInit;
        }
    }
}