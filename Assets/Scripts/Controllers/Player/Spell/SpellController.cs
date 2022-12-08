using UnityEngine;

public interface ISpellController {
    ISpell CurrentSpell { get; }
    void Initialize(Vector3 position, PlayerTeam playerTeam);
    void SetSpell(ISpell spellBase);
    void SetActive(bool active);
    void Clear();
}

public class SpellController : ISpellController {
    private readonly IContext context;
    private readonly UnitBaseBehaviour owner;

    private UIUnitSpellBase uiSPell;
    private RaycastUseSpell raycastSpell;

    public ISpell CurrentSpell { get; private set; }

    public SpellController(IContext context, UnitBaseBehaviour owner) {
        this.context = context;
        this.owner = owner;
    }

    public void Initialize(Vector3 position, PlayerTeam playerTeam) {
        raycastSpell = new RaycastUseSpell(context, this, owner);

        uiSPell = new UISpellBuilder(context).Build(position, playerTeam);
        uiSPell.OnTouchUp += raycastSpell.RaycastSpell;
    }

    public void SetSpell(ISpell spellBase) {
        CurrentSpell = spellBase;
        CurrentSpell.Initialize(uiSPell);
    }

    public void SetActive(bool active) {
        uiSPell.SetActive(active);
    }

    public void Clear() {
        GameObject.Destroy(uiSPell.gameObject);
    }
}
