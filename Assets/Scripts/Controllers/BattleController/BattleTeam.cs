using System;
using System.Collections.Generic;

public class BattleTeam {
    public LinkedList<UnitBaseBehaviour> Units { get; private set; }
    public event Action OnDiedAll;

    public void Initialize(List<UnitBaseBehaviour> unitList) {
        Units = new LinkedList<UnitBaseBehaviour>(unitList);

        foreach (var player in Units) {
            player.OnDie += DieUnit;
        }
    }

    private void DieUnit(UnitBaseBehaviour unitBaseBehaviour) {
        Units.Remove(unitBaseBehaviour);

        if (Units.Count <= 0) {
            OnDiedAll?.Invoke();
        }
    }

    public void Clear() {
        while (Units.Count > 0) {
            Units.Last.Value.OnDie -= DieUnit;
            Units.Last.Value.Clear.Clear();
            Units.RemoveLast();
        }
    }

    public void StepAll() {
        var currentPlayer = Units.First;

        while (currentPlayer != null) {
            currentPlayer.Value.BattleStep();
            currentPlayer = currentPlayer.Next;
        }
    }
}
