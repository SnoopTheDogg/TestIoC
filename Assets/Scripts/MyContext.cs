using strange.extensions.command.api;
using strange.extensions.command.impl;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;

public class MyContext : MVCSContext
{
    public MyContext(MonoBehaviour view)
        : base(view)
    {
    }

    public MyContext(MonoBehaviour view, ContextStartupFlags flags)
        : base(view, flags)
    {
    }

    protected override void mapBindings()
    {
        //injectionBinder.Bind<DownloadPanelMediator>().ToSingleton();
        //injectionBinder.Bind<ImagePanelMediator>().ToSingleton();
        //injectionBinder.Bind<MainPanelView>().ToSingleton();

        injectionBinder.Bind<OpenDownloadPanelSignal>().ToSingleton();
        injectionBinder.Bind<OpenImagePanelSignal>().ToSingleton();
        injectionBinder.Bind<DownloadImageSignal>().ToSingleton();
        injectionBinder.Bind<CloseImagePanelSignal>().ToSingleton();
        injectionBinder.Bind<CloseDownloadPanelSignal>().ToSingleton();
        injectionBinder.Bind<ImageModel>().ToSingleton();
        injectionBinder.Bind<ImageDownloadService>().ToSingleton();
        injectionBinder.Bind<OpenLoadingBarSignal>().ToSingleton();
        injectionBinder.Bind<CloseLoadingBarSignal>().ToSingleton();
        injectionBinder.Bind<UpdateLoadingBarSignal>().ToSingleton();
        injectionBinder.Bind<StopLoadingSignal>().ToSingleton();

        mediationBinder.Bind<DownloadPanelView>().To<DownloadPanelMediator>();
        mediationBinder.Bind<ImagePanelView>().To<ImagePanelMediator>();
        mediationBinder.Bind<MainPanelView>().To<MainPanelMediator>();
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }
}
