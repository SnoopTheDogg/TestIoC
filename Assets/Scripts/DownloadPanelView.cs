using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DownloadPanelView : View
{
    [SerializeField]
    private InputField _inputField;

    [SerializeField]
    private Button _downloadButton;

    [SerializeField]
    private Button _closeDownloadPanelButton;

    [SerializeField]
    private Image _loadingBar;
    
    [SerializeField]
    private Button _stopLoadingButton;
    
    [SerializeField]
    private Text _loadingText;
    public void AddDownloadButtonListener(UnityAction onClick)
    {
        _downloadButton.onClick.AddListener(onClick);
    }

    public void AddCloseDownloadButtonListner(UnityAction onClick)
    {
        _closeDownloadPanelButton.onClick.AddListener(onClick);
    }

    public void AddStopLoadingButtonListner(UnityAction onClick)
    {
        _stopLoadingButton.onClick.AddListener(onClick);
    }

    public string GetUrl()
    {
        return _inputField.text;
    }

    public void OpenLoadingBar()
    {
        _loadingBar.gameObject.SetActive(true);
        _stopLoadingButton.gameObject.SetActive(true);
    }

    public void UpdateLoadingBar(float percentage)
    {
        _loadingBar.fillAmount = percentage;
        _loadingText.text = string.Format("{0}%",(percentage * 100).ToString("0.##"));
    }

    public void CloseLoadingBar()
    {
        _loadingBar.gameObject.SetActive(false);
        _stopLoadingButton.gameObject.SetActive(false);
    }
}
