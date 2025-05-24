using UnityEngine;
using System.IO;

public class Basic : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        byte[] bytes = File.ReadAllBytes("./Assets/Textures/wallpaper.jpg");

        Texture2D texture = new Texture2D(100, 100);

        texture.filterMode = FilterMode.Trilinear;

        texture.LoadImage(bytes);

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        Material mat = new Material(Shader.Find("Unlit/Texture"));

        mat.mainTexture = texture;

        meshRenderer.material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                //Select stage    
                if (hit.transform.name == "Cube")
                {
                    Debug.Log("You hit the cube!");
                }
            }

        }
    }
}

