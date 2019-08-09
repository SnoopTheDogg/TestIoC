using strange.extensions.signal.impl;

public class DownloadImageSignal : Signal
{
}

public class OpenImagePanelSignal : Signal
{
}

public class OpenDownloadPanelSignal : Signal
{
}

public class CloseImagePanelSignal : Signal
{
}
public class CloseDownloadPanelSignal : Signal
{
}
public class UpdateLoadingBarSignal : Signal<float>
{
}

public class CloseLoadingBarSignal : Signal
{
}

public class OpenLoadingBarSignal : Signal
{
}

public class StopLoadingSignal : Signal
{
}