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
        [Inject] ISkillLearner _skillLearner;

        public List<ISkillViewArgs> Create()
        {
            var list = new List<ISkillViewArgs>();


            //ランダム数値
            var randomList = new List<int>();
            for(int i = 0; i < masterDataProvider.Count; i++)
            {
                randomList.Add(i);
            }
            for (int i = randomList.Count - 1; i > 0; i--)
            {
                var j = UnityEngine.Random.Range(0, i ); // ランダムで要素番号を１つ選ぶ（ランダム要素）
                var temp = randomList[i]; // 一番最後の要素を仮確保（temp）にいれる
                randomList[i] = randomList[j]; // ランダム要素を一番最後にいれる
                randomList[j] = temp; // 仮確保を元ランダム要素に上書き
            }


            for (int i = 0; i < masterDataProvider.Count; i++)
            {
                var master = masterDataProvider.TryGetFromIndex(randomList[i]).GetMaster();

                //すでに所持しているスキルは出さない
                if (_skillLearner.IsLearnSkill(master.Id)) continue;

                //コアスキルを持っていないスキルは出さない
                if (master.CoreSkillKey != "")
                {
                    if (!_skillLearner.IsLearnSkill(master.CoreSkillKey)) continue;
                }

                list.Add(Convert(master));

                if (list.Count == 3) break;
            }

            return list;
        }

        ISkillViewArgs Convert(ISkillMaster master)
        {
            return new SkillViewArgs(master.Id, master.DisplayName, master.Description, master.CardImagePath);
        }
    }
}