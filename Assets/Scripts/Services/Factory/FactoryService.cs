using System;
using System.Collections.Generic;

public interface IFactory {
}

public interface IFactoryService {
    T Get<T>() where T : IFactory;
}

public class FactoryService : IFactoryService {
    private Dictionary<Type, IFactory> factories;

    public FactoryService() {
        factories = new Dictionary<Type, IFactory> {
            {typeof(UnitFactory), new UnitFactory()},
            {typeof(UIFactory), new UIFactory()},
        };
    }

    public T Get<T>() where T : IFactory {
        return (T)factories[typeof(T)];
    }

}
