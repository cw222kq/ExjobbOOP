using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject prefab;
    
    public void ChangeColors(List<GameObject> cubes) 
    {
        foreach (GameObject cube in cubes) {
        
            cube.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f));           
                      
        }
    }
    
   
}
