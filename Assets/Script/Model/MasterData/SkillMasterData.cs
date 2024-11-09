using Tarahiro;
using Tarahiro.MasterData;
using System;
using System.Collections;
using UnityEngine;
using gaw241110.model;

namespace gaw241110.model.masterData
{
    //---プロジェクト作成時にやること---//
    //namespaceの"project"部分を変更。（gaw[yymmdd].modelとか）

    //---クラス作成時にやること---//
    //"Template" を置換
    //ITemplateMasterに合わせてフィールドを追加
    public class SkillMasterData : MasterDataOrderedDictionary<SkillMasterData.Record, IMasterDataRecord<ISkillMaster>>
    {
        public const string c_DataPath = "Data/Skill";

        [Serializable]
        public class Record : IMasterDataRecord<ISkillMaster>, ISkillMaster
        {
            public Record(int index, string id)
            {
                m_Index = index;
                m_Id = id;
            }

            [SerializeField] int m_Index;
            [SerializeField] string m_Id;
            [SerializeField] string m_DisplayName;
            [SerializeField] string m_Description;
            [SerializeField] string m_CardImagePath;
            [SerializeField] string m_SkillKey;
            [SerializeField] float m_SkillArg;


            public int Index => m_Index;
            public string Id => m_Id;
            public string DisplayName => m_DisplayName;
            public string Description => m_Description;
            public string CardImagePath => m_CardImagePath;
            public string SkillKey => m_SkillKey;
            public float SkillArg => m_SkillArg;

            public ISkillMaster GetMaster() => this;

#if UNITY_EDITOR
            public string SettableDisplayName { set => m_DisplayName = value; }
            public string SettableDescription { set => m_Description = value; }
            public string SettableCardImagePath { set => m_CardImagePath = value; }
            public string SettableSkillKey { set => m_SkillKey = value; }
            public float SettableSkillArg { set => m_SkillArg = value; }

#endif
        }
    }
}