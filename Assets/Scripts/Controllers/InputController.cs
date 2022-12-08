using System;
using UnityEngine;

public interface IInputController {
    event Action OnKeyDownR;
    event Action OnKeyDownSpace;

    void SetBlock(bool block);
}

public class InputController : MonoBehaviour, IInputController {
    public event Action OnKeyDownR;
    public event Action OnKeyDownSpace;

    private bool blocked;

    public void SetBlock(bool block) {
        blocked = block;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            OnKeyDownR?.Invoke();
        }

        if (blocked) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            OnKeyDownSpace?.Invoke();
        }
    }
}
