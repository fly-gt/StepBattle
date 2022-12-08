using System;
using UnityEngine;
using UnityEngine.UI;

public class WinPopup : UIPopupBase {
    [SerializeField] private Button restartButton;

    public event Action OnRestart;

    private void Awake() {
        restartButton.onClick.AddListener(RestartButton);
    }

    private void OnDestroy() {
        restartButton.onClick.RemoveAllListeners();
    }

    private void RestartButton() {
        Close();
        OnRestart?.Invoke();
    }
}
