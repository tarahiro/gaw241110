using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110
{
    public class GamePauser : IGamePauser
    {
        [Inject] private SignalBus _signalBus;


        public void Pause()
        {
            _signalBus.Fire<PauseSignal>();
        }

        public void Restart()
        {
            _signalBus.Fire<ResumeSignal>();
        }
    }
}