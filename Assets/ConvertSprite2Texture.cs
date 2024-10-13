using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ConvertSprite2Texture : MonoBehaviour
{
    public Sprite sprite;
    public bool convert = false;

    [SerializeField] private Texture2D _texturePreview;
    public Texture2D _Name => this._texturePreview;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
        if (convert)
        {
            convert = false;
            if (sprite == null) return;
            SaveSpriteAsTexture(sprite);
            
        }
    }

    public void SaveTexture(Texture2D texture2D)
    {
        this._texturePreview = texture2D;

        byte[] bytes = texture2D.EncodeToPNG();

        string directoryPath = Application.dataPath + "/SpriteToPNGFileOutput";

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        File.WriteAllBytes(directoryPath + "/Tex_" + GUID.Generate() + ".png", bytes);

        Debug.Log(bytes.Length / 1024 + "Kb was saved as: " + directoryPath);

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }

    public void SaveSpriteAsTexture(Sprite sprite)
    {
        Texture2D texture = new Texture2D(
            (int)sprite.textureRect.width,
            (int)sprite.textureRect.height
        );

        Color[] pixels = sprite.texture.GetPixels(
            (int)sprite.textureRect.x,
            (int)sprite.textureRect.y,
            (int)sprite.textureRect.width,
            (int)sprite.textureRect.height
        );

        texture.SetPixels(pixels);
        texture.Apply();

        this.SaveTexture(texture2D: texture);
    }
}
