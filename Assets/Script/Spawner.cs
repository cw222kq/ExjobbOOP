using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /*[SerilizeField] private int numberOfCubes; TODO work with protection level
    [SerilizeField] private int width;
    [SerilizeField] private int deep;
    [SerilizeField] private int height;*/

    public int numberOfCubes; 
    public int width;
    public int deep;
    public int height;
    int heightCounter = 0;
    int totalCubeCounter = 0;
    int maxWidth = 10;
    int maxDeep = 10;
    public List<GameObject> clones = new List<GameObject>();

     public void SetMaxDeep(int value)
   {
       maxDeep = value;
   }

   public int GetMaxDeep() 
   {
       return maxDeep;
   }
   public void SetMaxWidth(int value)
   {
       maxWidth = value;
   }

   public int GetMaxWidth() 
   {
       return maxWidth;
   }

   public int GetNumberOfCubes() 
   {   
       return numberOfCubes;
   }
   void Awake()
    {
        numberOfCubes = numberOfCubes;
        
    }
 
    public void SpawnCubes(Cube cube) 
    {
        while(totalCubeCounter<numberOfCubes) {
            // Every level in the cube will consist of max 100 cubes
            for(int i=0; i<maxWidth; i++) {//x width always the same
                for(int j=0; j<maxDeep; j++) {//z deep always the same
                
                    if(totalCubeCounter == numberOfCubes){
                            return;
                    }
                    totalCubeCounter++;
                    GameObject clone = Instantiate(cube.prefab, new Vector3(i,heightCounter,j), Quaternion.identity);
                    clone.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f));
                    clone.name = "Cube_" + totalCubeCounter; 
                    // Add the clone to the list of clones
                    clones.Add(clone);   
                }
            
            }
            // When 100 cubes has been built start the building on the next level
            heightCounter++;

        } 
        
    }
}
