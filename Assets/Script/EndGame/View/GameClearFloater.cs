using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;
using gaw241110;
using gaw241110.endgame;
using gaw241110.endgame.presenter;
using TMPro;
using LitMotion;
using LitMotion.Extensions;
using ModestTree;

namespace gaw241110.endgame.view
{
    public class GameClearFloater : MonoBehaviour, IGameClearFloater
    {
        public async UniTask Float()
        {
            await LMotion.Create(transform.position, transform.position + Vector3.up * 20f, 5f).WithEase(Ease.InCubic).BindToPosition(transform);
        }
    }
}