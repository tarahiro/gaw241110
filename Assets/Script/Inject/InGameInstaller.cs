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
using gaw241110.model.masterData;
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
#if ENABLE_DEBUG
            Container.BindInterfacesTo<DebugModelTicker>().AsSingle();
#endif

            Container.BindInterfacesTo<GameClearFloater>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<ScreenFader>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CheckGameOverView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<GamePauser>().AsSingle();



            Container.BindInterfacesTo<StackedObjViewArgsFactory>().AsSingle();
            Container.BindInterfacesTo<CookieParameter>().AsSingle();

            Container.BindInterfacesTo<SkillMasterDataProvider>().AsSingle();
            Container.BindInterfacesTo<SkillViewArgs>().AsSingle();
            Container.BindInterfacesTo<OfferedSkillViewArgsFactory>().AsSingle();
            Container.BindInterfacesTo<SkillLearner>().AsSingle();
            Container.BindInterfacesTo<CardMenuPresenter>().AsSingle();
            Container.BindInterfacesTo<CardMenuView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CardManager>().AsSingle();

            Container.BindInterfacesTo<EndGameViewProvider>().AsSingle();
            Container.BindInterfacesTo<EndGamePresenter>().AsSingle();
            Container.Bind<GameOverView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<GameClearView>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesAndSelfTo<CheckGamePresenter>().AsSingle();
            Container.BindInterfacesTo<EndGameManager>().AsSingle();

            Container.BindInterfacesAndSelfTo<MochiPresenter>().AsSingle();
            Container.BindInterfacesTo<MochiParameter>().AsSingle();
            Container.BindInterfacesTo<MochiModel>().AsSingle();
            Container.BindInterfacesTo<MochiMenuView>().FromComponentInHierarchy().AsSingle();

            Container.Bind<IPauseable>().To<MochiView>().FromComponentsInHierarchy().AsSingle();

            Container.BindInterfacesTo<CookieModel>().AsSingle();
            Container.BindInterfacesTo<StackedObjPresenter>().AsSingle();
            Container.BindInterfacesTo<StackedObjView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CatView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CookieView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<StackedObjModel>().AsSingle();
            Container.BindInterfacesTo<CookiePresenter>().AsSingle();

            Container.BindInterfacesTo<WarningFader>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<SeaWarningView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<SeaParameter>().AsSingle();
            Container.BindInterfacesAndSelfTo<SeaModel>().AsSingle();
            Container.BindInterfacesTo<SeaView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<SeaLevelUpView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<SeaPresenter>().AsSingle();
            Container.BindInterfacesTo<SeaTicker>().AsSingle();

            Container.BindInterfacesTo<AltitudeUiView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<ConverterCookieToExp>().AsSingle();
            Container.BindInterfacesTo<ExpView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<ExpModel>().AsSingle();
            Container.BindInterfacesTo<ExpPresenter>().AsSingle();

            Container.BindInterfacesTo<GameManager>().AsSingle();
            Container.BindInitializableExecutionOrder<GameManager>(-100);



            // SignalBusを利用する
            SignalBusInstaller.Install(Container);
            // Signalを定義する
            Container.DeclareSignal<PauseSignal>();
            Container.DeclareSignal<ResumeSignal>();
            // Signalを受け取った際の処理
            Container.BindSignal<PauseSignal>().ToMethod<IPauseable>(p => p.OnPause).FromResolveAll();
            Container.BindSignal<ResumeSignal>().ToMethod<IPauseable>(p => p.OnResume).FromResolveAll();

        }
    }
}
