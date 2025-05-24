using UnityEngine;
using System;


public class file1 : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Before transform: " + transform.position);
        transform.position = new Vector3(-2f, 0, 0);
        Debug.Log("After transform: " + transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, speed * Time.deltaTime, 0.0f));
    }
}
