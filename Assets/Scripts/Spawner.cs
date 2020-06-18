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
    private int heightCounter = 0;
    private int totalCubeCounter = 0;
    private int maxWidth = 10;
    private int maxDeep = 10;
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
   /*void Awake()
    {
        numberOfCubes = numberOfCubes; // TODO: Check if this line is really necessary?
        
    }*/
    public void SpawnCubes(Cube cube) 
    {
        // As long as the number of spawned cubes in the scene is smaller than numberOfCubes the spawner will keep on spawning cubes
        while(totalCubeCounter<numberOfCubes) {

            for(int i=0; i<maxWidth; i++) { // x width default value is 10
                for(int j=0; j<maxDeep; j++) { // z deep default value is 10
                
                    // This will end the while loop
                    if(totalCubeCounter == numberOfCubes){
                            return;
                    }

                    totalCubeCounter++;

                    // Instantiate GameObject
                    GameObject clone = Instantiate(cube.cubePrefab, new Vector3(i,heightCounter,j), Quaternion.identity);

                    // Set random material on the clone
                    clone.GetComponent<Renderer>().material = cube.cubeMaterials[(int)UnityEngine.Random.Range(0, 10)];

                    // Set mesh on the clone
                    clone.GetComponent<MeshFilter>().mesh = cube.cubeMesh;

                    // Set the name on the clone
                    // clone.name = "Cube_" + totalCubeCounter; DELETE TO MAKE IT MORE LIKE THE DOD VERSION

                    // Add the clone to the list of clones (This list is used for changing the colors of the cubes later on)
                    clones.Add(clone);   
                }
            
            }
            // When the first level of cubes (maxWidth*maxDeep) has been built start the building on the next level (i.e adding +1 to the height (y value))
            heightCounter++;

        } 
        
    }
}
