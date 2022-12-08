using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColletionSettingsBase<T> : ScriptableObject where T : MonoBehaviour
{
    [SerializeField] private List<T> ui;

    private Dictionary<Type, T> unitsDictionary;

    public K Get<K>() where K : class, T  {
        if (unitsDictionary == null) {
            unitsDictionary = ui.ToDictionary(x => x.GetType());
        }

        return unitsDictionary[typeof(K)] as K;
    }
}
