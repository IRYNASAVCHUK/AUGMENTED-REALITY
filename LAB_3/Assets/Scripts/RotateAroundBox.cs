using UnityEngine;

public class RotateAroundBox : MonoBehaviour
{
    public Transform target; 
    public float speed = 100f;

    void Update()
    {
        if (target != null)
        {
            transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
        }
    }
}

