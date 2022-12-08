using UnityEngine;

public abstract class UIBaseContext {
}

public abstract class UIBase : MonoBehaviour {
    protected IContext Context;

    public void Construct(IContext context) {
        Context = context;
    }
}

public abstract class UIBase<T> : UIBase 
    where T : UIBaseContext {
    protected T uiContext;
    public virtual void Initialize(T context) {
        this.uiContext = context;
    }
}
