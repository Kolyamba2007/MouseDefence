using strange.extensions.mediation.impl;
using UnityEngine;

public class ProjectileView : View
{
    public ProjectileData ProjectileData { get; private set; }

    public void SetData(ProjectileData projectileData)
    {
        ProjectileData = projectileData;

        GetComponent<SpriteRenderer>().sortingLayerName = $"Line{ProjectileData.LineNumber}";
    }
}
