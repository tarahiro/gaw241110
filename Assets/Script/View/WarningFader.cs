using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using LitMotion;
using LitMotion.Extensions;

namespace gaw241110.view
{
    public class WarningFader : MonoBehaviour, IWarningFader
    {
        [SerializeField] Image _warningImage;

        const float c_warningStartTime = .2f;
        const float c_warningLoopTime = .8f;
        const float c_warningIntencity = .3f;
        const float c_warningIntencityAmplitudeRate = .5f;

        MotionHandle _motionHandle;

        void Start()
        {
            Color c = _warningImage.color;
            c.a = 0f;
            _warningImage.color = c;
        }

        // Start’†‚ÉEnd‚ªŒÄ‚Î‚ê‚é‚ÆƒoƒO‚é‚Ì‚Å‚Ç‚¤‚É‚©‚·‚é
        public async UniTask Warning()
        {
            _motionHandle = LMotion.Create(_warningImage.color.a, c_warningIntencity, c_warningStartTime).BindToColorA(_warningImage);
            await _motionHandle;

            _motionHandle = LMotion.Create(c_warningIntencity, c_warningIntencity * (1 - c_warningIntencityAmplitudeRate), c_warningLoopTime)
                .WithLoops(-1)
                .BindToColorA(_warningImage); ;
            await _motionHandle;
        }

        public async UniTask EndWarning()
        {
            _motionHandle.Cancel();

            _motionHandle = LMotion.Create(_warningImage.color.a, 0, c_warningStartTime).BindToColorA(_warningImage);
            await _motionHandle;
        }
    }
}