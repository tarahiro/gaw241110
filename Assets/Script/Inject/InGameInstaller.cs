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
using gaw241110.endgame;
using gaw241110.endgame.presenter;
using gaw241110.endgame.view;
using gaw241110.endgame.model;
using Zenject.SpaceFighter;

namespace gaw241110.inject
{
    public class InGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GamePauser>().AsSingle();



            Container.BindInterfacesTo<CardMenuPresenter>().AsSingle();
            Container.BindInterfacesTo<CardMenuView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CardManager>().AsSingle();

            Container.BindInterfacesTo<EndGameViewContainer>().AsSingle();
            Container.BindInterfacesTo<EndGamePresenter>().AsSingle();
            Container.Bind<GameOverView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<GameClearView>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesTo<CheckGamePresenter>().AsSingle();
            Container.BindInterfacesTo<EndGameManager>().AsSingle();

            Container.BindInterfacesTo<StackedCookieView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CatView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CookieView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CookieModel>().AsSingle();
            Container.BindInterfacesTo<CookiePresenter>().AsSingle();

            Container.BindInterfacesTo<SeaModel>().AsSingle();
            Container.BindInterfacesTo<SeaView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<SeaPresenter>().AsSingle();
            Container.BindInterfacesTo<SeaTicker>().AsSingle();

            Container.BindInterfacesTo<ExpView>().AsSingle();
            Container.BindInterfacesTo<ExpModel>().AsSingle();
            Container.BindInterfacesTo<ExpPresenter>().AsSingle();

            Container.BindInterfacesTo<GameManager>().AsSingle();
            Container.BindInitializableExecutionOrder<GameManager>(-100);



            // SignalBusÇóòópÇ∑ÇÈ
            SignalBusInstaller.Install(Container);
            // SignalÇíËã`Ç∑ÇÈ
            Container.DeclareSignal<PauseSignal>();
            Container.DeclareSignal<ResumeSignal>();
            // SignalÇéÛÇØéÊÇ¡ÇΩç€ÇÃèàóù
            Container.BindSignal<PauseSignal>().ToMethod<IPauseable>(p => p.OnPause).FromResolveAll();
            Container.BindSignal<ResumeSignal>().ToMethod<IPauseable>(p => p.OnResume).FromResolveAll();

        }
    }
}
