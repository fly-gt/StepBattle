using UnityEngine;

public interface ICameraController {
    public Camera UICamera { get; }
    public Camera GameCamera { get; }
}

public class CameraController : MonoBehaviour, ICameraController {
    [field: SerializeField] public Camera UICamera { get; private set; }
    [field: SerializeField] public Camera GameCamera { get; private set; }
}
