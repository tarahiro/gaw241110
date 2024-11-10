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
    public class OfferedSkillViewArgsFactory : IOfferedSkillViewArgsFactory
    {
        [Inject] ISkillMasterDataProvider masterDataProvider;

        public List<ISkillViewArgs> Create()
        {
            var list = new List<ISkillViewArgs>();

            //とりあえず順番に出す
            for (int i = 0; i < masterDataProvider.Count; i++)
            {
                list.Add(Convert(masterDataProvider.TryGetFromIndex(i).GetMaster()));
            }

            return list;
        }

        ISkillViewArgs Convert(ISkillMaster master)
        {
            return new SkillViewArgs(master.Id, master.DisplayName, master.Description, master.CardImagePath);
        }
    }
}