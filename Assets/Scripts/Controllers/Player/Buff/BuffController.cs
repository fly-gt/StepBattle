using System;
using System.Collections.Generic;
using System.Linq;

public interface IBuffController {
    void SetBuff(IBuff buff);
    void Remove<T>() where T : IBuff;
    T Get<T>() where T : IBuff;
    void Step();
}

public class BuffController : IBuffController {
    private readonly Dictionary<Type, IBuff> buffs;
    private readonly IStatsController playerStats;

    public BuffController(IStatsController playerStats) {
        this.playerStats = playerStats;
        buffs = new Dictionary<Type, IBuff>();
    }

    public void SetBuff(IBuff buff) {
        if (buffs.TryGetValue(buff.GetType(), out IBuff value)) {
            value.ReBuff();
        } else {
            buff.Setup(playerStats);
            buffs[buff.GetType()] = buff;
        }
    }

    public void Step() {
        var buffList = buffs.Values.ToList();

        for (int i = buffList.Count - 1; i >= 0; i--) {
            buffList[i].Step();

            if (buffList[i].Steps <= 0) {
                buffList[i].Clear();
                buffs.Remove(buffList[i].GetType());
            }
        }
    }

    public void Remove<T>() where T : IBuff {
        if (buffs.TryGetValue(typeof(T), out IBuff value)) {
            value.Clear();
            buffs.Remove(typeof(T));
        }
    }

    public T Get<T>() where T : IBuff {
        if (buffs.TryGetValue(typeof(T), out IBuff value)) {
            return (T)value;
        } else {
            return default;
        }
    }
}
