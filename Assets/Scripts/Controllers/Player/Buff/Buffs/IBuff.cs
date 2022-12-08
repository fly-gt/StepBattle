public interface IBuff {
    int Steps { get; }
    void Setup(IStatsController stats);
    void Step();
    void Clear();
    void ReBuff();
}
