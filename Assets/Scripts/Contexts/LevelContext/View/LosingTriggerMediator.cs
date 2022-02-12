using UnityEngine;

public class LosingTriggerMediator : ViewMediator<LosingTrigger>
{
    public override void OnRegister()
    {
        View.FinishGameSignal.AddListener(() => Debug.Log("Losing")); ;
    }

    public override void OnRemove()
    {
        View.FinishGameSignal.RemoveAllListeners();
    }
}
