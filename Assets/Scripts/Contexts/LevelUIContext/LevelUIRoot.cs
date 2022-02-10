using System;
using UnityEngine;
using strange.extensions.context.impl;

public class LevelUIRoot : ContextView
{
    void Awake()
    {
        context = new LevelUIContext(this); 
    }
}
