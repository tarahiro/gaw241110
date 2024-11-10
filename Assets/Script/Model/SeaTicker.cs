using Cysharp.Threading.Tasks;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110.model
{
    public class SeaTicker: ISeaTicker
    {
        [Inject] ISeaModel _seaModel;


        bool _isActive = false;

        public void Activate()
        {
            _isActive = true;
        }

        public void InActivate()
        {
            _isActive = false;
        }

        public void Tick()
        {
            if (_isActive)
            {
                float coeff = 1f;

#if ENABLE_DEBUG
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    coeff *= 10f;
                }
#endif


                _seaModel.AddSea(Time.deltaTime * coeff);
            }
        }


        //Fake
        public void OnPause(PauseSignal signal)
        {
            InActivate();
        }
        public void OnResume(ResumeSignal signal)
        {
            Activate();
        }
    }
}