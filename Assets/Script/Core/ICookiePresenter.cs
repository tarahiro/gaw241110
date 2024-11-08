using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110
{
    public interface ICookiePresenter: IPauseable
    {
        void StopCookie();
        void StartCookie();
    }
}
