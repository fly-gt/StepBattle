using System;

public class SpellRandom {
    private readonly IContext context;
    private readonly ISpellController spell;
    public SpellRandom(IContext context, ISpellController spell) {
        this.context = context;
        this.spell = spell;
    }

    public ISpell GetSpell() {
        var random = RandomSpell();

        while (random.GetType() == spell.CurrentSpell?.GetType()) {
            random = RandomSpell();
        }

        return random;
    }

    private ISpell RandomSpell() {
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
