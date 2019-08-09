using System;
using System.Collections;
using RSG;
using UnityEngine;
using UnityEngine.Networking;

public class ImageDownloadService
{

    private static MonoBehaviour _coroutiner;

    private UnityWebRequest _webRequest;
    private Coroutine _currentCoroutine;
    
    [Inject]
    public ImageModel Image { get; set; }

    [Inject]
    public UpdateLoadingBarSignal UpdateLoadingBar { get; set; }

    [Inject]
    public CloseLoadingBarSignal CloseLoadingBar { get; set; }
    
    [Inject]
    public OpenLoadingBarSignal OpenLoadingBar { get; set; }

    public Promise DownloadImage(string url)
    {
        Promise promise = new Promise();
        _webRequest = UnityWebRequestTexture.GetTexture(new Uri(url));
        var result = _webRequest.SendWebRequest();

        if (_coroutiner == null)
        {
            _coroutiner = (new GameObject("Coroutiner")).AddComponent<Coroutiner>();
        }

        _currentCoroutine = _coroutiner.StartCoroutine(ShowLoadingBar(result));
        result.completed += operation =>
        {
            if (_webRequest != null)
            {
                promise.Resolve();
                Image.Texture = DownloadHandlerTexture.GetContent(_webRequest);
            }
            else
            {
                promise.Reject(new Exception("*CLICK* NOICE!"));
            }
        };

        return promise;
    }

    public void AbortLoading()
    {

        if (_currentCoroutine != null)
        {
            _coroutiner.StopCoroutine(_currentCoroutine);
        }
        if (_webRequest != null)
        {
            _webRequest.Abort();
            _webRequest = null;
        }
        CloseLoadingBar.Dispatch();
    }

    private IEnumerator ShowLoadingBar(UnityWebRequestAsyncOperation operation)
    {
        OpenLoadingBar.Dispatch();
        while (!operation.isDone)
        {
            UpdateLoadingBar.Dispatch(operation.progress);
            yield return null;
        }
        CloseLoadingBar.Dispatch();
    }
}

public class ImageModel
{
    public Texture Texture { get; set; }
}
