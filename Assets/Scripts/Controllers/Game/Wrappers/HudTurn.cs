using System;

public class HudTurn : IDisposable {
    private readonly IContext context;
    private readonly IBattleController battle;

    private UIHud uIHud;

    public HudTurn(IContext context, IBattleController battle) {
        this.context = context;
        this.battle = battle;
    }

    public void Dispose() {
        uIHud.OnEndTurn -= NextTurn;
    }

    public void Initialize() {
        uIHud = context.UIController.GetPopup<UIHud>();
        uIHud.OnEndTurn += NextTurn;
        uIHud.Render();
    }

    private void NextTurn() {
        battle.NextTurn();
    }
}
