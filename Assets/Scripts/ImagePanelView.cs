using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImagePanelView : View
{
    [SerializeField]
    private RawImage _image;

    [SerializeField]
    private Button _openDownloadPanelButton;

    [SerializeField]
    private Button _closeImagePanelButton;
    
    [SerializeField]
    private AspectRatioFitter _aspectRatioFitter;

    public void AddOpenDownloadPanelButtonListener(UnityAction onClick)
    {
        _openDownloadPanelButton.onClick.AddListener(onClick);
    }
    
    public void AddCloseImagePanelButtonListener(UnityAction onClick)
    {
        _closeImagePanelButton.onClick.AddListener(onClick);
    }

    public void ShowImage(Texture texture)
    {
        _aspectRatioFitter.aspectRatio = ((float)texture.width / texture.height);
        _image.texture = texture;
        _openDownloadPanelButton.gameObject.SetActive(false);
    }

    public void ShowButton()
    {
        _openDownloadPanelButton.gameObject.SetActive(true);
        _image.texture = null;
    }
}
