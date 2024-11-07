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
        public void Initialize()
        {
            Log.DebugLog("PlaySe");
            SoundManager.PlaySE("Enter");
        }
    }
}
