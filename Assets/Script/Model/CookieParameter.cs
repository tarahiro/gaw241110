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

        public int AddedCookieNumber { get; set; } = c_InitialAddedCookieNumber;
        public float Length { get; set; } = c_InitialCookieLength;
        public float Scale { get; set; } = 1f;

        public void MultiplyAddedCookieNumber(int multiplierFromInit)
        {
            AddedCookieNumber = c_InitialAddedCookieNumber * multiplierFromInit;
        }

        public void MultiplyLength(float multiplierFromInit)
        {
            Length = c_InitialCookieLength * multiplierFromInit;
            Scale = multiplierFromInit;
        }
    }
}