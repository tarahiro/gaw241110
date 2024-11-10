using Cysharp.Threading.Tasks;
using gaw241110;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter
{
    public class CookieViewArgs : ICookieViewArgs
    {
        float _length;

        public float Length => _length;

        public CookieViewArgs(float length)
        {
            _length = length;
        }
    }
}