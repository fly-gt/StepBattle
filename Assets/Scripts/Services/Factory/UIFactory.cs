using UnityEngine;

public class UIFactory : IFactory {
    private const string path = "UISettings";
    private UISettings settings;

    public UIFactory() {
        settings = Resources.Load<UISettings>(path);
    }

    public T Create<T>(Transform parent) where T : UIBase {
        var prefab = settings.Get<T>();
        var element = GameObject.Instantiate<T>(prefab, parent);

        return element;
    }
}
