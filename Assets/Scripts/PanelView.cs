using strange.extensions.mediation.impl;

public class PanelMediator : Mediator
{
    public virtual void Init()
    {
        Hide();
    }
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
