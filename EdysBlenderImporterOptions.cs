using UnityEngine;

public class EdysBlenderImporterOptions : ScriptableObject
    {

    public bool fixBlender = true;
    public bool optimize = false;
    public bool zReverse = false;
    public bool animFix = true;
    public bool floatFix = true;
    public bool postMods = true;
    public bool forceFixRoot = false;
    
    public float floatFixThreshold = 1.53e-05f;

    public override string ToString()
        {
        return
            (fixBlender ? "fixBlender " : "") +
                (optimize ? "optimize " : "") +
                (zReverse ? "zReverse " : "") +
                (animFix ? "animFix " : "") +
                (floatFix ? "floatFix " : "") +
                (postMods ? "postMods " : "") +
                (forceFixRoot ? "forceFixRoot " : "");
        }

#if UNITY_EDITOR

    [UnityEditor.MenuItem ("Assets/Create/EdysBlenderImporter Options", false, 9999)]
    static void CreateAsset ()
        {
        EdysBlenderImporterOptions asset = ScriptableObject.CreateInstance<EdysBlenderImporterOptions>();
        UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/New EdysBlenderImporterOptions.asset");
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.EditorUtility.FocusProjectWindow();
        UnityEditor.Selection.activeObject = asset;
        }

#endif

    }
