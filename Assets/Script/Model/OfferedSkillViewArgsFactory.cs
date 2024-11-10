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


            //�����_�����l
            var randomList = new List<int>();
            for(int i = 0; i < masterDataProvider.Count; i++)
            {
                randomList.Add(i);
            }
            for (int i = randomList.Count - 1; i > 0; i--)
            {
                var j = UnityEngine.Random.Range(0, i ); // �����_���ŗv�f�ԍ����P�I�ԁi�����_���v�f�j
                var temp = randomList[i]; // ��ԍŌ�̗v�f�����m�ہitemp�j�ɂ����
                randomList[i] = randomList[j]; // �����_���v�f����ԍŌ�ɂ����
                randomList[j] = temp; // ���m�ۂ��������_���v�f�ɏ㏑��
            }


            for (int i = 0; i < masterDataProvider.Count; i++)
            {
                var master = masterDataProvider.TryGetFromIndex(randomList[i]).GetMaster();

                //���łɏ������Ă���X�L���͏o���Ȃ�
                if (_skillLearner.IsLearnSkill(master.Id)) continue;

                //�R�A�X�L���������Ă��Ȃ��X�L���͏o���Ȃ�
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