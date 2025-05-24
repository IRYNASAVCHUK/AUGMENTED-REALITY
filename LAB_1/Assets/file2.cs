using UnityEngine;

public class file2 : MonoBehaviour
{
    public GameObject extObj;
    public GameObject extObj1;
    public Texture treeTexture; // Assegna la texture dall'Inspector

    void Start()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;

        // Configura extObj
        extObj.transform.position = transform.position + new Vector3(-3.0f, 0.0f, 0.0f);
        extObj.GetComponent<MeshRenderer>().material.color = Color.red;

        // Configura extObj1 (Prefab di un albero)
        extObj1.transform.position = transform.position + new Vector3(3.0f, 0.0f, 0.0f);

        // Se il prefab ha un MeshRenderer, assegniamo la texture
        Renderer renderer = extObj1.GetComponent<Renderer>();
        if (renderer != null && treeTexture != null)
        {
            foreach (Material mat in renderer.materials)
            {
                mat.mainTexture = treeTexture; // Applica la texture a tutti i materiali
            }
        }
    }

    void Update()
    {
        transform.Rotate(0.0f, 10.0f * Time.deltaTime, 0.0f);
        extObj.transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * 200.0f);
        extObj1.transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * -200.0f);
    }
}
