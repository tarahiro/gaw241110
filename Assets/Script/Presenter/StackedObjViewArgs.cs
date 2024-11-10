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
    public class StackedObjViewArgs : IStackedObjViewArgs
    {

        public string PrefabName { get; set; }
        public float Length { get; set; }
        public float Scale { get; set; }

        public StackedObjViewArgs(string prefabName, float length, float scale)
        {
            PrefabName = prefabName;
            Length = length;
            Scale = scale;
        }
    }
}