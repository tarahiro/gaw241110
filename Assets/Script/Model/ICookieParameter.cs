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
    public interface ICookieParameter
    {
        int AddedCookieNumber { get; }

        float CookieLength { get; }

        void MultiplyAddedCookieNumber(int multiplierFromInit);
        void MultiplyACookieLength(float multiplierFromInit);
    }
}