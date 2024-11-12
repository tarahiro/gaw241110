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
    public class SkillLearner:ISkillLearner,IInitializable
    {
        [Inject] ISkillMasterDataProvider masterDataProvider;
        [Inject] ICookieParameter cookieParameter;
        [Inject] IMochiParameter mochiParameter;
        [Inject] ISeaParameter seaParameter;

        List<string> _list;

        public void Initialize()
        {
            _list = new List<string>();
        }

        public void LearnSkill(string skillId)
        {
            _list.Add(skillId);
            InterpretSkill(masterDataProvider.TryGetFromId(skillId).GetMaster());
        }

        public bool IsLearnSkill(string skillId)
        {
            return _list.Contains(skillId);
        }

        void InterpretSkill(ISkillMaster master)
        {
            switch (master.SkillKey)
            {
                case "CookieHeightUp":
                    cookieParameter.MultiplyLength(master.SkillArg);
                    break;

               case "CookieNumberUp":
                    cookieParameter.MultiplyAddedCookieNumber((int)master.SkillArg);
                    break;

                case "MochiClickerAdd":
                    mochiParameter.AddMochiClicker();
                    break;

                case "MochiHeightUp":
                    mochiParameter.MultiplyLength(master.SkillArg);
                    break;

                case "MochiFillTimeChange":
                    mochiParameter.MultiplyFillTime(master.SkillArg);
                    break;

                case "SeaSpeedDown":
                    seaParameter.MultiplySeaRiseSpeed(master.SkillArg);
                    break;

                default:
                    Log.DebugAssert(master.SkillKey + "Ç™ë∂ç›ÇµÇ‹ÇπÇÒ");
                    break;
            }
        }
    }
}