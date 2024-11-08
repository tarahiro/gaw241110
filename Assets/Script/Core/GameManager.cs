using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using Tarahiro;
using UnityEditor;

namespace gaw241110
{
    public class GameManager : IGameManager, IInitializable
    {
        [Inject] ICookiePresenter cookiePresenter;
        [Inject] IActivateableTick _seaManager;

        public void Initialize()
        {
            _seaManager.Activate();
        }

        public void GameOver()
        {
            Log.DebugLog("GameOverManager.GameOver");
            GameObject.Destroy(GameObject.Find("SceneContext"));
        }
    }
}
