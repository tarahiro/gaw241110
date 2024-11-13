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


namespace gaw241110.view
{
    public class SeaLevelUpView:MonoBehaviour, ISeaLevelUpView
    {
        [SerializeField] GameObject _gameObject;

        void Start()
        {

            _gameObject.SetActive(false);
        }

        public void Show()
        {
            Perform().Forget();
        }

        //TODO:Dispose‚Æ‚©‚¿‚á‚ñ‚Æ‚â‚é
        async UniTask Perform()
        {
           _gameObject.SetActive(true);
            SoundManager.PlaySE("Alert");
            await UniTask.WaitForSeconds(2f);
            _gameObject.SetActive(false);
        }
    }
}