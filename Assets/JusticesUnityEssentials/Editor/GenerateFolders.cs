using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GenerateFolders : MonoBehaviour
{
    [MenuItem("Window/Justices Unity Essentials/Generate Project Folders")]
    public static void GenerateFolderAssets()
    {
        if (!AssetDatabase.IsValidFolder("Assets/Animations"))
            AssetDatabase.CreateFolder("Assets", "Animations");

        if (!AssetDatabase.IsValidFolder("Assets/Scenes"))
            AssetDatabase.CreateFolder("Assets", "Scenes");

        if (!AssetDatabase.IsValidFolder("Assets/Audio"))
            AssetDatabase.CreateFolder("Assets", "Audio");

        if (!AssetDatabase.IsValidFolder("Assets/Editor"))
            AssetDatabase.CreateFolder("Assets", "Editor");

        if (!AssetDatabase.IsValidFolder("Assets/Extensions"))
            AssetDatabase.CreateFolder("Assets", "Extensions");

        if (!AssetDatabase.IsValidFolder("Assets/Flares"))
            AssetDatabase.CreateFolder("Assets", "Flares");

        if (!AssetDatabase.IsValidFolder("Assets/Fonts"))
            AssetDatabase.CreateFolder("Assets", "Fonts");

        if (!AssetDatabase.IsValidFolder("Assets/Materials"))
            AssetDatabase.CreateFolder("Assets", "Materials");

        if (!AssetDatabase.IsValidFolder("Assets/Meshes"))
            AssetDatabase.CreateFolder("Assets", "Meshes");

        if (!AssetDatabase.IsValidFolder("Assets/Physics"))
            AssetDatabase.CreateFolder("Assets", "Physics");

        if (!AssetDatabase.IsValidFolder("Assets/Plugins"))
            AssetDatabase.CreateFolder("Assets", "Plugins");

        if (!AssetDatabase.IsValidFolder("Assets/Prefabs"))
            AssetDatabase.CreateFolder("Assets", "Prefabs");

        if (!AssetDatabase.IsValidFolder("Assets/Project"))
            AssetDatabase.CreateFolder("Assets", "Project");

        if (!AssetDatabase.IsValidFolder("Assets/Resources"))
            AssetDatabase.CreateFolder("Assets", "Resources");

        if (!AssetDatabase.IsValidFolder("Assets/Scripts"))
            AssetDatabase.CreateFolder("Assets", "Scripts");

        if (!AssetDatabase.IsValidFolder("Assets/Terrains"))
            AssetDatabase.CreateFolder("Assets", "Terrains");

        if (!AssetDatabase.IsValidFolder("Assets/Textures"))
            AssetDatabase.CreateFolder("Assets", "Textures");

        if (!AssetDatabase.IsValidFolder("Assets/Shaders"))
            AssetDatabase.CreateFolder("Assets", "Shaders");
    }
}
