using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationHandler : MonoBehaviour
{
    // Variables
    private int frames;
    private float countdown;
    private bool spawnedCubes;
    private static Cube cube;
    private static Spawner spawner;
    private static Explosion explosion;
    
    void Awake() // https://www.youtube.com/watch?v=fGshe3ILKnA
    {
        cube = GetComponent<Cube>();
        spawner = GetComponent<Spawner>();
        explosion = GetComponent<Explosion>();

    }

    // Start is called before the first frame update
    void Start()
    {
        ProcessUserInput();
        
        // x sec after the building has been built up an explosion will occur
        countdown = explosion.delay;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnedCubes)
        {
            // UNCOMMENT THIS LINE BELOW!!!!!!!
            spawner.SpawnCubes(cube);
            spawnedCubes = true;
        }
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !explosion.hasExplode) 
        {
            explosion.Explode(spawner);
        }
        // Change color of the cubes every every frame before the explosion
        if (!explosion.hasExplode) 
        {   
            // UNCOMMENT THIS LINE BELOW!!!!
            cube.ChangeColors(spawner.clones);
        }

        if(!explosion.hasExplode)
        {
            frames ++;
        }
        
    }

    // Checks the user input from the inspector. If width, deep and height is set to values those values will be used to set the numberOfCubes
    // If width, deep or height are set to zero the building of cubes will consist of the value set in the numberOfCubes field
    // Every complete level will consist of 100 cubes (default value)
    void ProcessUserInput() 
    {
        // If the user inputs width, deep or hight recalculate the maxWidth, maxDeep and the numberOfCubes
        if (spawner.width > 0 && spawner.deep > 0 && spawner.height > 0) 
        {
            spawner.SetMaxWidth(spawner.width);
            spawner.SetMaxDeep(spawner.deep);
            spawner.numberOfCubes = (spawner.width*spawner.deep)*spawner.height;
        
        }
            
    }  
}
