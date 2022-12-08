using System;
using UnityEngine;

public interface IStatsController {
    event Action OnNoHealth;
    int Health { get; }
    Transform BuffRoot { get; }
    void Initialize(Vector3 position, PlayerData playerData);
    void SetHealth(int health);
    void Clear();
    void SetProtection(bool active, int health = 0);
}

public class StatsController : IStatsController {
    private readonly IContext context;
    private UIUnitStats uiStats;

    public event Action OnNoHealth;
    public int Health { get; private set; }
    public Transform BuffRoot => uiStats.buffRoot;

    public StatsController(IContext context) {
        this.context = context;
    }

    public void Initialize(Vector3 position, PlayerData playerData) {
        Health = playerData.HP;
        uiStats = new UiStatsBuilder(context).Build(position, playerData);
    }

    public void SetHealth(int health) {
        Health = health;

        uiStats.SetHealth(Health);

        if (Health <= 0) {
            OnNoHealth?.Invoke();
        }
    }

    public void SetProtection(bool active, int health = 0) {
        uiStats.SetProtection(active, health);
    }

    public void Clear() {
        GameObject.Destroy(uiStats.gameObject);
    }
}
