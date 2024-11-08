using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace gaw241110.view
{
    public class ExpView : IExpView
    {
        [SerializeField] Image _gaugeImage;


        public void UpdateLevel(int nextLevel, int maxExp)
        {
            Log.DebugLog("View: UpdateLevel");
        }
        public void UpdateExp(int exp)
        {
            Log.DebugLog("View: UpdateExp");
        }
    }
}