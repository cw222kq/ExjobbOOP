using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject prefab;
    private float r;
    private float g;
    private float b;
    public List<Material> cubeMaterials = new List<Material>();
    public Mesh cubeMesh;
    
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
