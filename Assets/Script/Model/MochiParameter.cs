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
        const float c_InitialStackedObjLength = .2f;
        int _clickerNumber = 0;
        public float Length { get; set; } = c_InitialStackedObjLength;
        public float Scale { get; set; } = 1f;
        public event Action MochiClickerAdded;

        public void MultiplyLength(float multiplierFromInit)
        {
            Length = c_InitialStackedObjLength * multiplierFromInit;
            Scale = multiplierFromInit;
        }

        public void AddMochiClicker()
        {
            _clickerNumber++;
            MochiClickerAdded.Invoke();
        }
    }
}