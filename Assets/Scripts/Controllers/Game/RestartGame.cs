public class RestartGame {
    private readonly IBattleController battle;
    private readonly UnitsSpawner spawner;

    public RestartGame(IBattleController battle, UnitsSpawner spawner) {
        this.battle = battle;
        this.spawner = spawner;
    }

    public void Restart() {
        battle.Clear();
        var spawnResult = spawner.Spawn();
        battle.Initialize(spawnResult.Players, spawnResult.Enemies);
        battle.NextTurn();
    }
}
