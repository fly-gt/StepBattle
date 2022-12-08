using System;

public class SpellRandom {
    private readonly IContext context;
    public SpellRandom(IContext context) {
        this.context = context;
    }

    public ISpell GetSpell() {
        var random = UnityEngine.Random.Range(0, 4);

        return random switch {
            0 => new AttackSpell(),
            1 => new HealSpell(),
            2 => new PoisonSpell(context),
            3 => new ProtectionSpell(),
            _ => throw new Exception("RANDOM NUMBER NOT HAVE SPELL"),
        };
    }
}
