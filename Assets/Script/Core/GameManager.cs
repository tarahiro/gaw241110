using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using Tarahiro;

namespace gaw241110
{
    public class GameManager : IInitializable
    {
        [Inject]
        ICookiePresenter m_CookiePresenter;

        public void Initialize()
        {
            m_CookiePresenter.Enter().Forget();
        }
    }
}
