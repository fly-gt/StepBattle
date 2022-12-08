using System.Collections.Generic;
using System.Linq;

public class SpawnResult {
    public List<UnitBaseBehaviour> Players;
    public List<UnitBaseBehaviour> Enemies;
}

public class UnitsSpawner {
    private const int maxUnitOnTeam = 3;
    private readonly IContext context;
    private readonly GroundView groundView;
    private readonly IBattleController battle;

    public UnitsSpawner(IContext context, GroundView groundView, IBattleController battle) {
        this.context = context;
        this.groundView = groundView;
        this.battle = battle;
    }

    public SpawnResult Spawn() {
        var spawnResult = new SpawnResult();

        var factory = context.FactoryService.Get<UnitFactory>();

        var playersData = context.GameRoomService.GetPlayers().Take(maxUnitOnTeam).ToList();
        var enemiesData = context.GameRoomService.GetEnemies().Take(maxUnitOnTeam).ToList();

        spawnResult.Players = new List<UnitBaseBehaviour>(playersData.Count);
        spawnResult.Enemies = new List<UnitBaseBehaviour>(enemiesData.Count);

        for (int i = 0; i < playersData.Count; i++) {
            var player = factory.Create<PlayerController>(groundView.PlayersView.Positions[i].position);
            player.Construct(context, playersData[i], PlayerTeam.Player);
            player.Initialize();

            spawnResult.Players.Add(player);
        }


        for (int i = 0; i < enemiesData.Count; i++) {
            var enemy = factory.Create<BotController>(groundView.EnemiesView.Positions[i].position);
            enemy.Construct(context, enemiesData[i], PlayerTeam.Enemy);
            enemy.Initialize(battle);
            spawnResult.Enemies.Add(enemy);
        }

        return spawnResult;
    }
}