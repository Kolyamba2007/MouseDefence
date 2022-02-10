using System;
using UnityEngine;
using strange.extensions.context.impl;

public class MenuRoot : ContextView
{
    void Awake()
    {
        context = new MenuContext(this);
    }
}
