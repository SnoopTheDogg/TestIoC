using strange.extensions.mediation.impl;
using UnityEngine.Experimental.PlayerLoop;

public class ImagePanelMediator : PanelMediator
    {
        [Inject]
        public ImagePanelView ImagePanel { get; set; }

        [Inject]
        public OpenDownloadPanelSignal OpenDownloadPanel { get; set; }

        [Inject]
        public OpenImagePanelSignal OpenImagePanel { get; set; }

        [Inject]
        public ImageModel ImageModel { get; set; }

        [Inject]
        public CloseImagePanelSignal ClosePanel { get; set; }

        public override void OnRegister()
        {
            Init();
            base.OnRegister();
            ImagePanel.AddOpenDownloadPanelButtonListener(OpenDownloadPanel.Dispatch);
            ImagePanel.AddCloseImagePanelButtonListener(ClosePanel.Dispatch);
            OpenDownloadPanel.AddListener(Hide);
            OpenImagePanel.AddListener(OpenWithImage);
            ClosePanel.AddListener(Hide);
        }

        public void OpenWithImage()
        {
            if (ImageModel.Texture != null)
            {
                ImagePanel.ShowImage(ImageModel.Texture);
            }
            else
            {
                ImagePanel.ShowButton();
            }

            Open();
        }

    }
