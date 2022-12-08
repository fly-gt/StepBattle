using UnityEngine;

public abstract class UIBasePoopupContext : UIBaseContext {
}

public abstract class UIPopupBase : UIBase {
    public virtual void Render() {
        gameObject.SetActive(true);
    }

    public virtual void Close() {
        gameObject.SetActive(false);
    }
}

public abstract class UIPopupBase<T> : UIPopupBase
    where T : UIBasePoopupContext {
    protected T uiContext;

    public virtual void Initialize(T context) {
        this.uiContext = context;
    }
}
