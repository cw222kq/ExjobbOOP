using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    private float r;
    private float g;
    private float b;
    [SerializeField] private List<Material> cubeMaterials = new List<Material>();
    [SerializeField] private Mesh cubeMesh;

    public GameObject CubePrefab { get => cubePrefab; set => cubePrefab = value; }
    public List<Material> CubeMaterials { get => cubeMaterials; set => cubeMaterials = value; }
    public Mesh CubeMesh { get => cubeMesh; set => cubeMesh = value; }

    // Randomize rgb values and set it to the cubes material
    public void ChangeColors(List<GameObject> cubes) 
    {
        foreach (GameObject cube in cubes) {

            r = Random.Range(0f, 1f);
            g = Random.Range(0f, 1f);
            b = Random.Range(0f, 1f);
        
            cube.GetComponent<Renderer>().material.color = new Color(r, g, b);           
                      
        }
    }
    
   
}
