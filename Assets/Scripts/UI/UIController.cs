using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public interface IUIController {
    T GetElement<T>() where T : UIElementBase;
    T GetPopup<T>() where T : UIPopupBase;
}

public class UIController : MonoBehaviour, IUIController {
    [SerializeField] private Transform RootElements;
    [SerializeField] private Transform RootPopups;

    [SerializeField] private List<UIPopupBase> uIPopups;

    private Dictionary<Type, UIPopupBase> popups;

    private IContext context;

    private void Awake() {
        popups = uIPopups.ToDictionary(x => x.GetType());
    }

    public void Initialize(IContext context) {
        this.context = context;
    }

    public T GetPopup<T>() where T : UIPopupBase {
        return popups[typeof(T)] as T;
    }

    public T GetElement<T>() where T : UIElementBase {
        var element = context.FactoryService.Get<UIFactory>().Create<T>(RootElements);
        element.Construct(context);

        return element;
    }
}
