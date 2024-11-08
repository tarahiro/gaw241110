using Cysharp.Threading.Tasks;
using gaw241110;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter
{
    public interface IAcceptableInput
    {
        event Action Decided;
        void AcceptInput();
        void StopAcceptInput();
    }
}