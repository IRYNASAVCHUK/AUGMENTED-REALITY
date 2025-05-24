using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    public Transform orbitCenter;       // Target to orbit around
    public float orbitSpeedMin = 1f;
    public float orbitSpeedMax = 30f;

    public float selfRotationSpeedMin = 1f;
    public float selfRotationSpeedMax = 10f;

    private float orbitSpeed;
    private float selfRotationSpeed;
    private Vector3 orbitAxis;

    void Start()
    {
        orbitSpeed = Random.Range(orbitSpeedMin, orbitSpeedMax);
        selfRotationSpeed = Random.Range(selfRotationSpeedMin, selfRotationSpeedMax);
        orbitAxis = Vector3.up; // Default orbit axis (Y-axis)
    }

    void Update()
    {
        if (orbitCenter != null)
        {
            transform.RotateAround(orbitCenter.position, orbitAxis, orbitSpeed * Time.deltaTime);
        }

        transform.Rotate(Vector3.up * selfRotationSpeed * Time.deltaTime, Space.Self);

    }
}
