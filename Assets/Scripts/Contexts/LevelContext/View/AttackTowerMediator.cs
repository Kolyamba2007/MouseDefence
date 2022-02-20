public class AttackTowerMediator : TowerMediator<AttackTowerView>
{
    [Inject] public IPowerService PowerService { get; set; }

    [Inject] public FireSignal FireSignal { get; set; }
    [Inject] public SetPowerActiveSignal SetPowerActiveSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        View.DetectSignal.AddListener(OnEnemyDetect);
        SetPowerActiveSignal.AddListener(OnSetActive);

        View.InitFinishSignal.AddListener(() =>
        {
            PowerService.SetRequiredPower(View.TowerData.PowerUsage, Enums.Mode.Addition);

            if (PowerService.IsPowerActive)
                View.StartDetecting();
        });
    }

    public override void OnRemove()
    {
        base.OnRemove();

        View.StopDetecting();

        View.DetectSignal.RemoveListener(OnEnemyDetect);
        SetPowerActiveSignal.RemoveListener(OnSetActive);

        View.InitFinishSignal.RemoveAllListeners();
        PowerService.SetRequiredPower(View.TowerData.PowerUsage, Enums.Mode.Subtraction);
    }

    public void OnEnemyDetect(float distance)
    {
        var td = View.TowerData;
        var projectileData = new ProjectileData(td.Damage, td.ProjectileSpeed, distance, View.FirePoint, View.Line);

        FireSignal.Dispatch(td.ProjectileView, projectileData);
    }

    private void OnSetActive(bool isActive)
    {
        if (isActive)
            View.StartDetecting();
        else
            View.StopDetecting();
    }
}
