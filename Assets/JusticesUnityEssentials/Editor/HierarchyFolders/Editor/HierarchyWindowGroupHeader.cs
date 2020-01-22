#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class HierarchyWindowGroupHeader
{
    static HierarchyWindowGroupHeader()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
    }

    static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        #region Red
        if (gameObject != null && gameObject.name.StartsWith("!!!", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(255, 0, 0, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("!", "").ToUpperInvariant());
        }
        else if (gameObject != null && gameObject.name.StartsWith("!!", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(176, 46, 46, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("!", "").ToUpperInvariant());
        }
        else if (gameObject != null && gameObject.name.StartsWith("!", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(133, 52, 52, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("!", "").ToUpperInvariant());
        }
        #endregion
        #region Green
        else if (gameObject != null && gameObject.name.StartsWith("@@@", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(0, 255, 0, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("@", "").ToUpperInvariant());
        }
        else if (gameObject != null && gameObject.name.StartsWith("@@", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(30, 212, 87, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("@", "").ToUpperInvariant());
        }
        else if (gameObject != null && gameObject.name.StartsWith("@", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(51, 145, 80, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("@", "").ToUpperInvariant());
        }
        #endregion
        #region Blue
        else if (gameObject != null && gameObject.name.StartsWith("###", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(0, 0, 255, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("#", "").ToUpperInvariant());
        }
        else if (gameObject != null && gameObject.name.StartsWith("##", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(55, 59, 171, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("#", "").ToUpperInvariant());
        }
        else if (gameObject != null && gameObject.name.StartsWith("#", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(55, 57, 120, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("#", "").ToUpperInvariant());
        }
        #endregion
        #region Misc
        else if (gameObject != null && gameObject.name.StartsWith("$$$", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(102, 255, 204, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("$", "").ToUpperInvariant());
        }
        else if (gameObject != null && gameObject.name.StartsWith("$$", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(255, 255, 255, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("$", "").ToUpperInvariant());
        }
        else if (gameObject != null && gameObject.name.StartsWith("$", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(0, 0, 0, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("$", "").ToUpperInvariant());
        }
        else if (gameObject != null && gameObject.name.StartsWith("%%%", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(51, 204, 51, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("%", "").ToUpperInvariant());
        }
        else if (gameObject != null && gameObject.name.StartsWith("%%", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(255, 153, 51, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("%", "").ToUpperInvariant());
        }
        else if (gameObject != null && gameObject.name.StartsWith("%", System.StringComparison.Ordinal))
        {
            EditorGUI.DrawRect(selectionRect, new Color32(255, 255, 102, 255));
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("%", "").ToUpperInvariant());
        }
        #endregion
        else
        {
            if (gameObject != null)
            {
                if (gameObject.activeSelf)
                {
                    if (!EditorGUI.ToggleLeft(new Rect(selectionRect.x, selectionRect.y, selectionRect.width * 0.1f, selectionRect.height), GUIContent.none, true))
                    {
                        Undo.RecordObject(gameObject, "Change activity");
                        gameObject.SetActive(false);
                        EditorUtility.SetDirty(gameObject);
                    }
                }
                else
                {
                    if (EditorGUI.ToggleLeft(new Rect(selectionRect.x, selectionRect.y, selectionRect.width * 0.1f, selectionRect.height), GUIContent.none, false))
                    {
                        Undo.RecordObject(gameObject, "Change activity");
                        gameObject.SetActive(true);
                        EditorUtility.SetDirty(gameObject);
                    }
                }

                if (gameObject.activeInHierarchy)
                {
                    if (HierarchyExtender.objectInstances.Contains(gameObject))
                    {
                        int index = -1;

                        for (int i = 0; i < HierarchyExtender.instances.Count; i++)
                        {
                            if (HierarchyExtender.objectInstances[i] == gameObject)
                            {
                                index = i;
                            }
                        }

                        if (index == -1) return;

                        //HierarchyExtender.instances[index].highlightColor = EditorGUI.ColorField(new Rect(200, selectionRect.y, 30, selectionRect.height), HierarchyExtender.instances[index].highlightColor);
                        
                        if (HierarchyExtender.instances[index].highlightColor != Color.black)
                        {
                            EditorGUI.DrawRect(selectionRect, HierarchyExtender.instances[index].highlightColor);
                            EditorGUI.DropShadowLabel(selectionRect, gameObject.name);
                        }
                    }
                    else gameObject.AddComponent<HierarchyExtender>();
                }
            }
        }
    }
}
#endif