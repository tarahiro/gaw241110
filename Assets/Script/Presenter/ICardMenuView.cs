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

        //�����ŃJ�[�h�̈�����n���A���͌��ߑł�
        void Show();
        void Hide();

        event Action CardSelected;
    }
}