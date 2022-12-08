using UnityEngine;

public class UISpellBuilder {
    private readonly IContext context;
    public UISpellBuilder(IContext context) {
        this.context = context;
    }

    public UIUnitSpellBase Build(Vector3 position, PlayerTeam playerTeam) {
        var spellPoint = playerTeam == PlayerTeam.Player ? position + Vector3.left : position + Vector3.right;
        var screenPoint = context.CameraController.GameCamera.WorldToScreenPoint(spellPoint);

        var uiSPell = context.UIController.GetElement<UIUnitSpellBase>();
        uiSPell.SetScreenPoint(screenPoint);

        return uiSPell;
    }
}
