using System.Collections;
using System.Collections.Generic;
using Rubiks;
using UnityEngine;

public class RubiksMeshGenerator : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spacing = .1f;
    [SerializeField] private RCube prefab;
    [SerializeField] private RubiksCube rubiks;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnPoint.childCount == 0)
        {
            GenerateCubes();
        }
    }

    [ContextMenu("Generate Cubes")]
    public void GenerateCubes()
    {
        rubiks.GenerateCubes(spawnPoint, prefab, spacing);
    }

    [ContextMenu("Color cubes")]
    public void ColorCubes()
    {
        rubiks.ColorCubes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
