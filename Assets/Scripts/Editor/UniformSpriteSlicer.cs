using UnityEngine;
using UnityEditor;

public class UniformSpriteSlicer : EditorWindow
{
    private Texture2D texture;
    private int sliceWidth = 32;
    private int sliceHeight = 32;
    private bool enforceUniformSize = true;

    [MenuItem("Tools/Uniform Sprite Slicer")]
    public static void ShowWindow()
    {
        GetWindow<UniformSpriteSlicer>("Uniform Sprite Slicer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Sprite Slicer Settings", EditorStyles.boldLabel);
        texture = (Texture2D)EditorGUILayout.ObjectField("Texture", texture, typeof(Texture2D), false);
        sliceWidth = EditorGUILayout.IntField("Slice Width", sliceWidth);
        sliceHeight = EditorGUILayout.IntField("Slice Height", sliceHeight);
        enforceUniformSize = EditorGUILayout.Toggle("Enforce Uniform Size", enforceUniformSize);

        if (GUILayout.Button("Slice"))
        {
            if (texture != null)
            {
                string path = AssetDatabase.GetAssetPath(texture);
                TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;

                if (ti != null && ti.textureType == TextureImporterType.Sprite)
                {
                    ti.spriteImportMode = SpriteImportMode.Multiple;

                    var spriteRects = new System.Collections.Generic.List<SpriteMetaData>();
                    int texWidth = texture.width;
                    int texHeight = texture.height;

                    for (int y = texHeight; y > 0; y -= sliceHeight)
                    {
                        for (int x = 0; x < texWidth; x += sliceWidth)
                        {
                            int w = enforceUniformSize ? sliceWidth : Mathf.Min(sliceWidth, texWidth - x);
                            int h = enforceUniformSize ? sliceHeight : Mathf.Min(sliceHeight, y);

                            if (x + w <= texWidth && y - h >= 0)
                            {
                                var smd = new SpriteMetaData
                                {
                                    alignment = 0,
                                    border = Vector4.zero,
                                    name = $"slice_{x}_{y}",
                                    pivot = new Vector2(0.5f, 0.5f),
                                    rect = new Rect(x, y - h, w, h)
                                };
                                spriteRects.Add(smd);
                            }
                        }
                    }

                    ti.spritesheet = spriteRects.ToArray();
                    EditorUtility.SetDirty(ti);
                    ti.SaveAndReimport();
                }
                else
                {
                    Debug.LogError("Selected texture is not a sprite or importer is invalid.");
                }
            }
            else
            {
                Debug.LogError("Please select a texture.");
            }
        }
    }
}
