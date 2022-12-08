public class ProtectionBuff : IBuff {
    private const int totalSteps = 3;
    private const int protection = 5;
    private IStatsController stats;
    public int Protection { get; private set; }
    public int Steps { get; private set; }

    public void Clear() {
        stats.SetProtection(false);
    }

    public void Setup(IStatsController stats) {
        this.stats = stats;
        ReBuff();
    }

    public void Step() {
        Steps--;
    }

    public void ReBuff() {
        Steps = totalSteps;
        Protection = protection;
        stats.SetProtection(true, Protection);
    }

    public void SpendProtection(int damage) {
        Protection -= damage;
    }
}
