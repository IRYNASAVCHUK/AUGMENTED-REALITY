using UnityEngine;

public class primitive : MonoBehaviour
{
    private GameObject MyCube, MyCylinder;
    // Start is called before the first frame update
    void Start()
    {
        MyCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        MyCube.transform.position = new Vector3(-5.0f, 0.0f, 0.0f);
        MyCube.GetComponent<MeshRenderer>().material.color = Color.red;
        MyCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        MyCylinder.transform.position = new Vector3(5.0f, 0.0f, 0.0f);
        MyCylinder.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    // Update is called once per frame
    void Update()
    {
        MyCube.transform.Rotate(50.0f * Time.deltaTime * Vector3.up);
        MyCylinder.transform.Rotate(50.0f * Time.deltaTime * new Vector3(1.0f, 0.0f, 0.0f));
    }
}
