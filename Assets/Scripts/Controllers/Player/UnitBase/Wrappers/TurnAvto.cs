using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnAvto {
    private readonly IContext context;
    private readonly IBattleController battle;
    private readonly ISpellController spell;
    private readonly UnitBaseBehaviour owner;
    private readonly EventSystem eventSystem;

    public TurnAvto(IContext context, IBattleController battle, ISpellController spell, UnitBaseBehaviour owner) {
        this.context = context;
        this.battle = battle;
        this.spell = spell;
        this.owner = owner;

        eventSystem = EventSystem.current;
    }

    public IEnumerator DoTurn() {
        SetTouchTurn(true);
        yield return new WaitForSeconds(1f);
        spell.CurrentSpell.Use(owner, RandomPlayer());
        yield return new WaitForSeconds(1f);
        battle.NextTurn();
        SetTouchTurn(false);
    }

    public void Clear() {
        SetTouchTurn(false);
    }

    private UnitBaseBehaviour RandomPlayer() {
        var random = Random.Range(0, battle.PlayersTeam.Units.Count);
        return battle.PlayersTeam.Units.ElementAt(random);
    }

    private void SetTouchTurn(bool active) {
        context.InputController.SetBlock(active);

        if (eventSystem != null) {
            eventSystem.enabled = !active;
        }
    }
}
