using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private GroundView groundView;

    private IContext context;
    private IBattleController battle;

    private UnitsSpawner unitsSpawner;
    private BattleEnd battleEnd;
    private HudTurn hudTurn;
    private RestartGame restartGame;

    private void OnDestroy() {
        battleEnd.Dispose();
        hudTurn.Dispose();

        context.InputController.OnKeyDownR -= restartGame.Restart;
        context.InputController.OnKeyDownSpace -= battle.NextTurn;
    }

    public void Initialize(IContext context) {
        this.context = context;

        battle = new BattleController();
        unitsSpawner = new UnitsSpawner(this.context, groundView, battle);
        restartGame = new RestartGame(battle, unitsSpawner);

        battleEnd = new BattleEnd(battle, context, restartGame);
        hudTurn = new HudTurn(context, battle);
        hudTurn.Initialize();

        var spawnResult = unitsSpawner.Spawn();

        battle.Initialize(spawnResult.Players, spawnResult.Enemies);

        context.InputController.OnKeyDownR += restartGame.Restart;
        context.InputController.OnKeyDownSpace += battle.NextTurn;
    }

    public void Render() {
        battle.NextTurn();
    }
}
