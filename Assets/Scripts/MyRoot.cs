using strange.extensions.context.impl;


public class MyRoot : ContextView
{
    private void Awake()
    {
        context = new MyContext(this);
    }
}
