using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using Tarahiro;
using gaw241110;
using gaw241110.presenter;
using gaw241110.view;
using gaw241110.model;

namespace gaw241110.inject
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings() {
            Container.BindInterfacesTo<CookieView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CookieModel>().AsSingle();
            Container.BindInterfacesTo<CookiePresenter>().AsSingle();
            Container.BindInterfacesTo<GameManager>().AsSingle();

            Container.BindInitializableExecutionOrder<GameManager>(-100);
        }
    }
}