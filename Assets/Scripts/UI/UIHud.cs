using System;
using UnityEngine;
using UnityEngine.UI;

public class UIHud : UIPopupBase {
    [SerializeField] private Button endTurnButton;

    public event Action OnEndTurn;

    private void Awake() {
        endTurnButton.onClick.AddListener(EndTurnClick);
    }

    private void OnDestroy() {
        endTurnButton.onClick.RemoveAllListeners();
    }

    private void EndTurnClick() {
        OnEndTurn?.Invoke();
    }
}
