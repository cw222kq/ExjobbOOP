using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int numberOfCubes; 
    [SerializeField] private int width;
    [SerializeField] private int deep;
    [SerializeField] private int height;
    private int heightCounter = 0;
    private int totalCubeCounter = 0;
    private int maxWidth = 10;
    private int maxDeep = 10;
    private bool spawnedCubes;
    private List<GameObject> cubes = new List<GameObject>();

    public int NumberOfCubes { get => numberOfCubes; set => numberOfCubes = value; }
    public int Width { get => width; set => width = value; }
    public int Deep { get => deep; set => deep = value; }
    public int Height { get => height; set => height = value; }
    public int MaxWidth { get => maxWidth; set => maxWidth = value; }
    public int MaxDeep { get => maxDeep; set => maxDeep = value; }
    public bool SpawnedCubes { get => spawnedCubes; set => spawnedCubes = value; }
    public List<GameObject> Cubes { get => cubes; set => cubes = value; }

    public void SpawnCubes(Cube cube) 
    {
        // As long as the number of spawned cubes in the scene is smaller than numberOfCubes the spawner will keep on spawning cubes
        while(totalCubeCounter<NumberOfCubes) {

            for(int i=0; i<MaxWidth; i++) { // x width default value is 10
                for(int j=0; j<MaxDeep; j++) { // z deep default value is 10
                
                    // This will end the while loop
                    if(totalCubeCounter == NumberOfCubes){
                            return;
                    }

                    totalCubeCounter++;

                    // Instantiate GameObject
                    GameObject theInstance = Instantiate(cube.CubePrefab, new Vector3(i,heightCounter,j), Quaternion.identity);

                    // Set random material on the instance
                    theInstance.GetComponent<Renderer>().material = cube.CubeMaterials[(int)UnityEngine.Random.Range(0, 10)];

                    // Set mesh on the instance
                    theInstance.GetComponent<MeshFilter>().mesh = cube.CubeMesh;

                    // Add the instance to the list of cubes (This list is used for changing the colors of the cubes later on)
                    Cubes.Add(theInstance);
                }
            
            }
            // When the first level of cubes (maxWidth*maxDeep) has been built start the building on the next level (i.e adding +1 to the height (y value))
            heightCounter++;

        } 

        //Set spawedCubes to true so the SpawnCube method only gets executed once
        SpawnedCubes = true; 
    }
}
