using System;
using UnityEngine;

public enum PlayerTeam {
    Player, Enemy
}

public abstract class UnitBaseBehaviour : MonoBehaviour {
    [SerializeField] protected Transform StatsPoint;

    protected IContext Context;
    protected ISpellController spell;
    private IStatsController stats;

    private PlayerData playerData;

    public event Action<UnitBaseBehaviour> OnDie;

    public IBuffController Buff { get; private set; }
    public ClearUnit Clear { get; private set; }
    public HealthChange Health { get; private set; }
    public PlayerTeam PlayerTeam { get; private set; }

    public void Construct(IContext context, PlayerData playerData, PlayerTeam playerTeam) {
        Context = context;
        this.playerData = playerData;
        PlayerTeam = playerTeam;

        stats = new StatsController(Context);
        spell = new SpellController(Context, this);
        Buff = new BuffController(stats);
        Clear = new ClearUnit(spell, stats, this);
        Health = new HealthChange(stats, Buff);
    }

    public virtual void Initialize() {
        stats.Initialize(StatsPoint.position, playerData);
        spell.Initialize(transform.position, PlayerTeam);

        stats.OnNoHealth += Die;
    }

    public virtual void BattleStep() {
        Buff.Step();
    }

    public abstract void Turn(bool turn);

    private void Die() {
        OnDie?.Invoke(this);
        Clear.Clear();
    }
}
