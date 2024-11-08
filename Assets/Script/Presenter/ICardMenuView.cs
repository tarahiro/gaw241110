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
    public interface ICardMenuView
    {

        //ここでカードの引数を渡す、今は決め打ち
        void Show();
        void Hide();

        event Action CardSelected;
    }
}