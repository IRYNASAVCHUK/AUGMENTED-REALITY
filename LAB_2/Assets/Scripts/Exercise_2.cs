using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Exercise_2 : MonoBehaviour
{
    private int cubeCount = 100;
    private float minX, maxX, minY, maxY, minZ, maxZ, minV, maxV;
    private List<GameObject> cubes = new List<GameObject>();

    void Start()
    {
        LoadConfig(Application.dataPath + "/config.txt");
        GenerateCubes();
    }

    void LoadConfig(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("Config file not found: " + filePath);
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            if (parts.Length < 2 || parts[0].StartsWith("#")) continue;

            switch (parts[0])
            {
                case "N": cubeCount = int.Parse(parts[1]); break;
                case "minX": minX = float.Parse(parts[1]); break;
                case "maxX": maxX = float.Parse(parts[1]); break;
                case "minY": minY = float.Parse(parts[1]); break;
                case "maxY": maxY = float.Parse(parts[1]); break;
                case "minZ": minZ = float.Parse(parts[1]); break;
                case "maxZ": maxZ = float.Parse(parts[1]); break;
                case "minV": minV = float.Parse(parts[1]); break;
                case "maxV": maxV = float.Parse(parts[1]); break;
            }
        }
    }

    void GenerateCubes()
    {
        for (int i = 0; i < cubeCount; i++)
        {
            // Generating random position and scale for each cube
            Vector3 position = new Vector3(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY),
                Random.Range(minZ, maxZ)
            );

            Vector3 scale = Vector3.one * Random.Range(0.5f, 2f);
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = position;
            cube.transform.localScale = scale;

            // Set random color
            Renderer renderer = cube.GetComponent<Renderer>();
            renderer.material.color = new Color(Random.value, Random.value, Random.value);

            // Add random rotation component and pass a random rotation speed
            cubes.Add(cube);
            cube.AddComponent<RandomRotation>().SetRandomRotationSpeed(Random.Range(minV, maxV*10));
        }
    }
}

public class RandomRotation : MonoBehaviour
{
    private float rotationSpeed;
    private Vector3 rotationAxis;

    // Set a random rotation speed and a random rotation axis
    public void SetRandomRotationSpeed(float speed)
    {
        rotationSpeed = speed;
        rotationAxis = new Vector3(Random.value, Random.value, Random.value).normalized; // Random axis
    }

    void Update()
    {
        // Rotate the cube around the random axis with the specified speed
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
