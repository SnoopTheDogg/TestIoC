using strange.extensions.mediation.api;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;


public class MainPanelView : View
{
    [SerializeField]
    private Button _openDownloadPanelbutton;
    [SerializeField]
    private Button _openImagePanelbutton;


    public void AddOpenDownloadPanelListener(UnityAction onClick)
    {
        _openDownloadPanelbutton.onClick.AddListener(onClick);
    }
    public void AddOpenImagePanelListener(UnityAction onClick)
    {
        _openImagePanelbutton.onClick.AddListener(onClick);
    }

}
