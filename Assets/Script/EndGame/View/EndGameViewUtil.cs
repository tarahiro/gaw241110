using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using Tarahiro;
using gaw241110;
using gaw241110.endgame;
using gaw241110.endgame.presenter;

namespace gaw241110.endgame.view
{
    public static class EndGameViewUtil
    {

        public static void StopSounds()
        {
            SoundManager.StopBGM(0);
            SoundManager.StopLoopSE();
        }
    }
}