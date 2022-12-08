public class HealthChange {
    private const int maxHealth = 30;
    private readonly IStatsController stats;
    private readonly IBuffController buff;

    public HealthChange(IStatsController stats, IBuffController buff) {
        this.stats = stats;
        this.buff = buff;
    }

    public void Refill(int refill) {
        var heal = stats.Health + refill;
        heal = heal.MaxLerp(maxHealth);
        stats.SetHealth(heal);
    }

    public void Damage(int damage) {
        var protectionBuff = buff.Get<ProtectionBuff>();

        if (protectionBuff != null) {
            protectionBuff.SpendProtection(damage);

            if (protectionBuff.Protection <= 0) {
                stats.SetHealth(stats.Health + protectionBuff.Protection);
                stats.SetProtection(false);
                buff.Remove<ProtectionBuff>();
            } else {
                stats.SetProtection(true, protectionBuff.Protection);
            }

        } else {
            var health = stats.Health - damage;
            health = health.ZeroLerp();
            stats.SetHealth(health);
        }
    }
}
