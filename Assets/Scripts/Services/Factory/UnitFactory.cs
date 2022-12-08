using UnityEngine;

public class UnitFactory : IFactory {
    private const string path = "GameSettings";
    private GameSettings settings;

    public UnitFactory() {
        settings = Resources.Load<GameSettings>(path);
    }

    public T Create<T>(Vector3 pos) where T : UnitBaseBehaviour {
        var prefab = settings.Get<T>();
        var unit = GameObject.Instantiate<T>(prefab, pos, prefab.transform.rotation);

        return unit;
    }
}
