using Cysharp.Threading.Tasks;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110
{
    public class SeaManager: ITickable,IActivateableTick
    {
        [Inject] ISeaModel _seaModel;


        bool _isActive = false;

        public void Activate()
        {
            _isActive = true;
        }

        public void Tick()
        {
            if (_isActive)
            {
                _seaModel.AddSea(_seaModel.GetSeaRiseSpeed * Time.deltaTime);
            }
        }
    }
}