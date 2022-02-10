using System;
using UnityEngine;
using strange.extensions.context.impl;

public class MainRoot : ContextView
{
    void Awake()
    {
        context = new MainContext(this);

        DontDestroyOnLoad(this.gameObject);
    }
}
