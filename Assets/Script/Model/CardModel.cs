using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.Model;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;


namespace gaw241110.model
{
    public class CardModel:IInitializable,ICardModel
    {
        [Inject] ITemplateMasterDataProvider masterDataProvider;

        public void Initialize()
        {
            Log.DebugLog(masterDataProvider.TryGetFromIndex(0).GetMaster().FakeDescription);
        }
    }
}