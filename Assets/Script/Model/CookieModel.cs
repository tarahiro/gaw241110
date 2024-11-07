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
    public class CookieModel : ICookieModel
    {
        int _cookieNumber = 0;
        public event Action CookieAdded;

        public void AddCookie()
        {
            _cookieNumber++;
            Log.DebugLog(_cookieNumber.ToString());

            Log.DebugAssert(CookieAdded != null);
            CookieAdded.Invoke();
        }
    }
}