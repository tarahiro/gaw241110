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
    public class MochiParameter : IMochiParameter
    {
        const float c_InitialStackedObjLength = 2f;
        const float c_InitialFillTime = 5f;
        int _clickerNumber = 0;
        float _fillTime = c_InitialFillTime;
        public float Length { get; set; } = c_InitialStackedObjLength;
        public float Scale { get; set; } = 1f;
        event Action MochiClickerAdded;
        event Action<float> FillTimeChanged;
        public void  StartModel(Action act, Action<float> timeAct)
        {
            MochiClickerAdded += act;
            FillTimeChanged += timeAct;
            FillTimeChanged.Invoke(_fillTime);
        }

        public void MultiplyLength(float multiplierFromInit)
        {
            Length = c_InitialStackedObjLength * multiplierFromInit;
            Scale = multiplierFromInit;
        }

        public void MultiplyFillTime(float coeff)
        {
            _fillTime = c_InitialFillTime * coeff;
            FillTimeChanged?.Invoke(_fillTime);
        }

        public void AddMochiClicker()
        {
            _clickerNumber++;
            MochiClickerAdded.Invoke();
        }
    }
}