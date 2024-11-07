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
        [Inject] ICookiePresenter cookiePresenter;
        [Inject] IManager _seaManager;

        public void Initialize()
        {
            _seaManager.Activate();
        }
    }
}
