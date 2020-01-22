#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HierarchyExtender : MonoBehaviour
{
    public static List<HierarchyExtender> instances = new List<HierarchyExtender>();
    public static List<GameObject> objectInstances = new List<GameObject>();
    public Color highlightColor = Color.black;

    private void OnEnable()
    {
        if(instances.Contains(this))
            instances.Remove(this);            
        if(objectInstances.Contains(gameObject))
            objectInstances.Remove(gameObject);

        objectInstances.Add(gameObject);
        instances.Add(this);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < instances.Count; i++)
        {
            if (instances[i] == this)
            {
                objectInstances.Remove(objectInstances[i]);
                instances.Remove(instances[i]);
            }
        }
    }
}
#endif