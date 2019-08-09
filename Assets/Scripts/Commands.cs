using strange.extensions.command.impl;
using UnityEngine;

public class DownloadImageCommand : Command
{
    public override void Execute()
    {
    }
}

public class OpenDownloadPanelCommand : Command
{
    public override void Execute()
    {
    }
}

public class OpenImagePanelCommand : Command
{
    public override void Execute()
    {
        Debug.Log("Button clicked");
    }
}
