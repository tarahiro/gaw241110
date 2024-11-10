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
    public class CardModel:ICardModel
    {
        [Inject] ISkillMasterDataProvider masterDataProvider;


        public void LearnSkill(string skillId)
        {
            Log.DebugLog(masterDataProvider.TryGetFromId(skillId).GetMaster().SkillKey);
        }
    }
}