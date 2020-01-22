using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GenerateSceneFolders : MonoBehaviour
{
    [MenuItem("Window/Justices Unity Essentials/Generate Scene Object Folders")]
    public static void GenerateSceneAssets()
    {
        GameObject @object1 = new GameObject();
        @object1.name = "#Cameras";
        @object1.SetActive(false);
        EditorUtility.SetDirty(@object1);

        GameObject @object2 = new GameObject();
        @object2.name = "%Lights";
        @object2.SetActive(false);
        EditorUtility.SetDirty(@object2);

        GameObject @object3 = new GameObject();
        @object3.name = "@Essential Objects";
        @object3.SetActive(false);
        EditorUtility.SetDirty(@object3);

        GameObject @object4 = new GameObject();
        @object4.name = "!!!Player";
        @object4.SetActive(false);
        EditorUtility.SetDirty(@object4);

        GameObject @object5 = new GameObject();
        @object5.name = "@@Terrain";
        @object5.SetActive(false);
        EditorUtility.SetDirty(@object5);

        GameObject @object6 = new GameObject();
        @object6.name = "!UI";
        @object6.SetActive(false);
        EditorUtility.SetDirty(@object6);

        GameObject @object7 = new GameObject();
        @object7.name = "###Particle Systems";
        @object7.SetActive(false);
        EditorUtility.SetDirty(@object7);
    }
}