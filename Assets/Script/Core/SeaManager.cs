using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110
{
    public class SeaManager: ITickable,IManager
    {
        bool _isActive = false;

        public void Activate()
        {
            _isActive = true;
        }

        public void Tick()
        {
            if (_isActive)
            {
                Log.DebugLog("TickTest");
            }
        }
    }
}