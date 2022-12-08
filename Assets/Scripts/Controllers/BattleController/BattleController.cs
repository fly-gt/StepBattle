using System;
using System.Collections.Generic;

public interface IBattleController {
    event Action OnWin;
    event Action OnLose;
    void Initialize(List<UnitBaseBehaviour> playersList, List<UnitBaseBehaviour> enemiesList);
    void NextTurn();
    void Clear();
    BattleTeam PlayersTeam { get; }
}

public class BattleController : IBattleController {
    public BattleTeam PlayersTeam { get; }
    private BattleTeam enemiesTeams;

    private LinkedListNode<UnitBaseBehaviour> current;

    public event Action OnWin;
    public event Action OnLose;

    public BattleController() {
        PlayersTeam = new BattleTeam();
        enemiesTeams = new BattleTeam();
    }

    public void Initialize(List<UnitBaseBehaviour> playersList, List<UnitBaseBehaviour> enemiesList) {
        PlayersTeam.Initialize(playersList);
        enemiesTeams.Initialize(enemiesList);

        PlayersTeam.OnDiedAll += DiePlayers;
        enemiesTeams.OnDiedAll += DieEnemies;
    }

    public void NextTurn() {
        if (current == null) {
            current = PlayersTeam.Units.First;
        } else {
            current.Value.Turn(false);

            if (current.Next == null) {
                if (current.Value.PlayerTeam == PlayerTeam.Player) {
                    current = enemiesTeams.Units.First;
                } else {
                    StepAllUnits();
                    current = PlayersTeam.Units.First;
                }
            } else {
                current = current.Next;
            }
        }

        current?.Value.Turn(true);
    }
    public void Clear() {
        PlayersTeam.Clear();
        enemiesTeams.Clear();
        current = null;
    }

    private void StepAllUnits() {
        PlayersTeam.StepAll();
        enemiesTeams.StepAll();
    }

    private void DiePlayers() {
        OnLose?.Invoke();
    }

    private void DieEnemies() {
        OnWin?.Invoke();
    }
}
