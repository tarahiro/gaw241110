using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;

namespace gaw241110
{
    public class ProjectManager : IInitializable
    {
        [Inject] SceneContext _sceneContext;

        public void Initialize()
        {
            Log.DebugLog(_sceneContext.name);
            _sceneContext.Run();
        }

    }
}