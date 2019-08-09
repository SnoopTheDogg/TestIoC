using strange.extensions.mediation.impl;

public class MainPanelMediator : PanelMediator
{
    [Inject]
    public MainPanelView MainPanel { get; set;}
    [Inject]
    public OpenDownloadPanelSignal OpenDownloadPanel { get; set; }
    [Inject]
    public OpenImagePanelSignal OpenImagePanel { get; set; }

    public override void Init()
    {
        base.Init();
        Open();
    }
    
    public override void OnRegister()
    {
        Init();
        base.OnRegister();
        MainPanel.AddOpenDownloadPanelListener(OpenDownloadPanel.Dispatch);
        MainPanel.AddOpenImagePanelListener(OpenImagePanel.Dispatch);
    }
}
