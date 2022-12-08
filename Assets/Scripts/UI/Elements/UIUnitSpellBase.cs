using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitSpellContext : UIBaseElementContext {
    public string Name;
}

public class UIUnitSpellBase : UIElementBase<UnitSpellContext>, IPointerDownHandler, IDragHandler, IPointerUpHandler {
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Text spellText;
    [SerializeField] private Image spellImage;
    [SerializeField] private Color select;
    [SerializeField] private Color noSelect;

    private UIUnitSpellBase dragSpell;

    public event Action OnTouchUp;

    public override void Initialize(UnitSpellContext uiContext) {
        base.Initialize(uiContext);
        spellText.text = uiContext.Name;
    }

    public void SetScreenPoint(Vector3 screenPoint) {
        rectTransform.anchoredPosition = screenPoint;
    }

    public void SetActive(bool active) {
        spellImage.raycastTarget = active;
        spellImage.color = active ? select : noSelect;
    }

    public void OnPointerDown(PointerEventData eventData) {
        dragSpell = Context.UIController.GetElement<UIUnitSpellBase>();
        dragSpell.gameObject.name = "drag";
        dragSpell.Initialize(uiContext);
        dragSpell.SetScreenPoint(rectTransform.anchoredPosition);
        dragSpell.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData) {
        dragSpell.SetScreenPoint(Input.mousePosition);
    }

    public void OnPointerUp(PointerEventData eventData) {
        Destroy(dragSpell.gameObject);
        OnTouchUp?.Invoke();
    }
}
