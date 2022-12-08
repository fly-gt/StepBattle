using UnityEngine;

public class UiStatsBuilder {
    private readonly IContext context;
    public UiStatsBuilder(IContext context) {
        this.context = context;
    }

    public UIUnitStats Build(Vector3 position, PlayerData playerData) {
        var statsScreenPoint = context.CameraController.GameCamera.WorldToScreenPoint(position);

        var uiContext = new UnitStatsContext() {
            HP = playerData.HP,
            Name = playerData.Name,
        };

        var uiStats = context.UIController.GetElement<UIUnitStats>();
        uiStats.SetScreenPoint(statsScreenPoint);
        uiStats.Initialize(uiContext);

        return uiStats;
    }
}
