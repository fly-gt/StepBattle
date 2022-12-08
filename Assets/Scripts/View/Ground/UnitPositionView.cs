using System.Collections.Generic;
using UnityEngine;

public class UnitPositionView : MonoBehaviour {
    [field: SerializeField] public List<Transform> Positions { get; private set; }
}
