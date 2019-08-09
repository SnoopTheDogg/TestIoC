using strange.extensions.mediation.impl;

public class DownloadPanelMediator : PanelMediator
{
    [Inject]
    public DownloadPanelView DownloadPanel { get; set; }

    [Inject]
    public DownloadImageSignal DownloadImage { get; set; }

    [Inject]
    public OpenDownloadPanelSignal OpenDownloadPanel { get; set; }

    [Inject]
    public ImageDownloadService ImageDownloader { get; set; }

    [Inject]
    public CloseDownloadPanelSignal ClosePanel { get; set; }

    [Inject]
    public UpdateLoadingBarSignal  UpdateLoadingBar { get; set; }

    [Inject]
    public OpenLoadingBarSignal OpenLoadingBar { get; set; }

    [Inject]
    public CloseLoadingBarSignal CloseLoadingBar { get; set; }
    
    [Inject]
    public StopLoadingSignal StopLoading { get; set; }

    public override void OnRegister()
    {
        Init();
        base.OnRegister();
        DownloadPanel.AddDownloadButtonListener(DownloadImage.Dispatch);
        DownloadPanel.AddCloseDownloadButtonListner(ClosePanel.Dispatch);
        DownloadPanel.AddStopLoadingButtonListner(StopLoading.Dispatch);
        OpenDownloadPanel.AddListener(Open);
        DownloadImage.AddListener(DownloadImageByUrl);
        ClosePanel.AddListener(Hide);
        OpenLoadingBar.AddListener(DownloadPanel.OpenLoadingBar);
        CloseLoadingBar.AddListener(DownloadPanel.CloseLoadingBar);
        UpdateLoadingBar.AddListener(DownloadPanel.UpdateLoadingBar);
        StopLoading.AddListener(AbortLoading);
    }

    public void AbortLoading()
    {
        ImageDownloader.AbortLoading();
    }
    
    public void DownloadImageByUrl()
    {
        ImageDownloader.DownloadImage(GetUlr()).Then(Hide);
    }
    
    public string GetUlr()
    {
        return DownloadPanel.GetUrl();
    }
}
