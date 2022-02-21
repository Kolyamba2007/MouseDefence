using strange.extensions.mediation.impl;

public abstract class ProjectileView : View
{
    public ProjectileData ProjectileData { get; private set; }

    public abstract void Init();

    public void SetData(ProjectileData projectileData) => 
        ProjectileData = projectileData;
}
