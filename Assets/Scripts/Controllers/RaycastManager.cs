using UnityEngine;

public interface IRaycastManager {
    GameObject RaycastTouch(string layer);
}

public class RaycastManager : IRaycastManager {
    public GameObject RaycastTouch(string layer) {
        var playerIndex = LayerMask.NameToLayer(layer);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] raycastHits = Physics.RaycastAll(ray);

        foreach (var hit in raycastHits) {
            if (hit.collider.gameObject.layer == playerIndex) {
                return hit.collider.gameObject;
            }
        }

        return null;
    }

}
