using strange.extensions.context.impl;

public class LevelRoot : ContextView
{
    void Awake()
    {
        context = new LevelContext(this);
    }
}
