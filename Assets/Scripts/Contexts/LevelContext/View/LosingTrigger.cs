using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class LosingTrigger : View
{
    public Signal FinishGameSignal { get; } = new Signal();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            FinishGameSignal.Dispatch();
    }
}