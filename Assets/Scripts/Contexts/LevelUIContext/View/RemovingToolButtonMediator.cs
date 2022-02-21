using strange.extensions.context.api;
using UnityEngine;

public class RemovingToolButtonMediator : ViewMediator<RemovingToolButtonView>
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }

    [Inject] public StartLevelSignal StartLevelSignal { get; set; }
    [Inject] public PauseMenuCallSignal PauseMenuCallSignal { get; set; }
    [Inject] public FinishLevelSignal FinishLevelSignal { get; set; }
    [Inject] public ClearLevelSignal ClearLevelSignal { get; set; }

    public override void OnRegister()
    {
        StartLevelSignal.AddListener(OnLevelStart);
        ClearLevelSignal.AddListener(DisableInteractable);
        FinishLevelSignal.AddListener((_) => DisableInteractable());

        View.ClickSignal.AddListener(OnClick);
    }

    public override void OnRemove()
    {
        StartLevelSignal.RemoveListener(OnLevelStart);
        ClearLevelSignal.RemoveListener(DisableInteractable);
        FinishLevelSignal.RemoveAllListeners();
        PauseMenuCallSignal.RemoveListener(OnPauseCall);

        View.ClickSignal.RemoveListener(OnClick);
    }

    private void OnClick()=>
        Instantiate(View.Prefab, ContextView.transform);

    private void OnLevelStart()
    {
        View.Button.interactable = true;

        PauseMenuCallSignal.AddListener(OnPauseCall);
    }

    private void OnPauseCall(bool isOpen) => View.Button.interactable = !isOpen;

    private void DisableInteractable() => View.Button.interactable = false;
}
