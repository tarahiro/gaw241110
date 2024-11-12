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
    public interface IMochiParameter : IStackedObjParameter
    {
        void AddMochiClicker();
        void MultiplyFillTime(float coeff);
        void StartModel(Action act, Action<float> timeAct);
    }
}