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
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<StackedCookieView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CookieView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CookieModel>().AsSingle();
            Container.BindInterfacesTo<CookiePresenter>().AsSingle();

            Container.BindInterfacesTo<SeaModel>().AsSingle();
            Container.BindInterfacesTo<SeaView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<SeaPresenter>().AsSingle();
            Container.BindInterfacesTo<SeaManager>().AsSingle();




            Container.BindInterfacesTo<GameManager>().AsSingle();

            Container.BindInitializableExecutionOrder<GameManager>(-100);
        }
    }
}
