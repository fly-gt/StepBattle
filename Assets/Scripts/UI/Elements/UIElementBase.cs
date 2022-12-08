
public abstract class UIBaseElementContext : UIBaseContext {
}

public abstract class UIElementBase : UIBase
{
}

public abstract class UIElementBase<T> : UIElementBase 
        where T : UIBaseElementContext {
    protected T uiContext;
    public virtual void Initialize(T context) {
        this.uiContext = context;
    }
}
