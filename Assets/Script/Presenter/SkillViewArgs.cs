using Cysharp.Threading.Tasks;
using gaw241110;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter
{
    public class SkillViewArgs : ISkillViewArgs
    {
        string m_SkillId;
        string m_DisplayName;
        string m_Description;
        string m_ImagePath;


        public string SkillId => m_SkillId;
        public string DisplayName => m_DisplayName;
        public string Description => m_Description;
        public string ImagePath => m_ImagePath;

        public SkillViewArgs(string skillId, string displayName, string description, string imagePath)
        {
            m_SkillId = skillId;
            m_DisplayName = displayName;
            m_Description = description;
            m_ImagePath = imagePath;
        
        }
    }
}