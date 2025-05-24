using UnityEngine;
using System;

public class in_mouse : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select target
                //if (hit.transform.CompareTag("mouse"))
                if (hit.transform.name == "Sphere")
                {
                    hit.transform.gameObject.GetComponent<MeshRenderer>().material.color =
                    new Color(UnityEngine.Random.Range(0.5f, 1f), UnityEngine.Random.Range(0.5f, 1f), 0);
                }
            }
        }
    }
}
