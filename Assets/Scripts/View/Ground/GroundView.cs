using UnityEngine;

public class GroundView : MonoBehaviour {
    [field: SerializeField] public UnitPositionView PlayersView { get; private set; }
    [field: SerializeField] public UnitPositionView EnemiesView { get; private set; }
}
