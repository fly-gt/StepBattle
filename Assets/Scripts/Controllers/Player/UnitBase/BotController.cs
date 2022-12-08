using UnityEngine;

public class BotController : UnitBaseBehaviour {
    private TurnAvto turnAvto;
    private Coroutine turnCoroutine;

    public void Initialize(IBattleController battle) {
        Initialize();

        spell.SetSpell(new AttackSpell());
        turnAvto = new TurnAvto(Context, battle, spell, this);
    }

    public override void Turn(bool turn) {
        spell.SetActive(turn);

        if (!turn) {
            return;
        }

        turnCoroutine = StartCoroutine(turnAvto.DoTurn());
    }


    private void OnDisable() {
        if (turnCoroutine != null) {
            turnAvto.Clear();
            turnCoroutine = null;
        }
    }
}
