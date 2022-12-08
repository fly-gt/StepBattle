public class RaycastUseSpell {
    private readonly IContext context;
    private readonly ISpellController spell;
    private readonly UnitBaseBehaviour owner;

    public RaycastUseSpell(IContext context, ISpellController spell, UnitBaseBehaviour owner) {
        this.context = context;
        this.spell = spell;
        this.owner = owner;
    }

    public void RaycastSpell() {
        var raycastObject = context.RaycastManager.RaycastTouch("Unit");

        if (raycastObject != null) {
            var unit = raycastObject.transform.parent.GetComponent<UnitBaseBehaviour>();
            UseSpell(unit);
        }
    }

    private void UseSpell(UnitBaseBehaviour target) {
        var result = spell.CurrentSpell.Use(owner, target);

        if (result) {
            spell.SetActive(false);
        }
    }
}
