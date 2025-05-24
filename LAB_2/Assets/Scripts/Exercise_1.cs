using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Exersice_1 : MonoBehaviour
{private List<Texture2D> textures = new List<Texture2D>(); 
    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        LoadTextures(Application.dataPath + "/Textures");

        if (textures.Count > 0)
        {
            ApplyRandomTexture();
        }
        else
        {
            Debug.LogError("No textures found in Assets/Textures!");
        }
    }

    void LoadTextures(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Debug.LogError("Folder not found: " + folderPath);
            return;
        }

        string[] files = Directory.GetFiles(folderPath, "*.jpg");
        string[] files2 = Directory.GetFiles(folderPath, "*.png");

        foreach (string file in files)
            textures.Add(LoadTexture(file));
        foreach (string file in files2)
            textures.Add(LoadTexture(file));
    }

    Texture2D LoadTexture(string filePath)
    {
        byte[] bytes = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        return texture;
    }

    void ApplyRandomTexture()
    {
        if (textures.Count > 0)
        {
            Texture randomTexture = textures[Random.Range(0, textures.Count)];
            cubeRenderer.material.mainTexture = randomTexture;
        }
    }

    void OnMouseDown()
    {
        ApplyRandomTexture();
    }
}
