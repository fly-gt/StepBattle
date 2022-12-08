using UnityEngine;
using UnityEngine.UI;

public class UnitStatsContext : UIBaseElementContext {
    public string Name;
    public int HP;
}

public class UIUnitStats : UIElementBase<UnitStatsContext> {
    [field: SerializeField] public Transform buffRoot { get; private set; }
    [SerializeField] private Text nameText;
    [SerializeField] private Text hpText;
    [SerializeField] private Text protectionText;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private RectTransform rectTransform;

    public override void Initialize(UnitStatsContext context) {
        base.Initialize(context);

        nameText.text = context.Name;
        hpText.text = context.HP.ToString();
        hpSlider.minValue = 0;
        hpSlider.maxValue = context.HP;
        hpSlider.value = context.HP;
    }

    public void SetScreenPoint(Vector3 screenPoint) {
        rectTransform.anchoredPosition = screenPoint;
    }

    public void SetHealth(int hp) {
        hpText.text = hp.ToString();
        hpSlider.value = hp;
    }

    public void SetProtection(bool active, int health = 0) {
        if (active) {
            protectionText.gameObject.SetActive(true);
            protectionText.text = $"<color=blue>+{health}</color>";

            return;
        }

        protectionText.gameObject.SetActive(false);
    }
}