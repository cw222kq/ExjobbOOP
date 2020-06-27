using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationHandler : MonoBehaviour
{
    // Variables
    private float countdown;
    private int framesCounter;
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
        countdown = explosion.Delay;

        // Initialize framesCounter
        framesCounter = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawner.SpawnedCubes)
        {
            spawner.SpawnCubes(cube);
        }

        countdown -= Time.deltaTime;
        framesCounter ++;

        if (countdown <= 0f && !explosion.HasExplode) 
        {
            explosion.Explode(spawner);
        }
        // Change color of the cubes every every frame before the explosion
        if (!explosion.HasExplode) 
        {   
            cube.ChangeColors(spawner.Cubes);
        }

        // When the frames reach 600 end the simulation
        if (framesCounter == 600) 
        {
            Application.Quit();
        }
      
    }

    // Checks the user input from the inspector. If width, deep and height is set to values those values will be used to set the numberOfCubes
    // If width, deep or height are set to zero the building of cubes will consist of the value set in the numberOfCubes field
    // Every complete level will consist of 100 cubes (default value)
    void ProcessUserInput() 
    {
        // If the user inputs width, deep or hight recalculate the maxWidth, maxDeep and the numberOfCubes
        if (spawner.Width > 0 && spawner.Deep > 0 && spawner.Height > 0) 
        {
            spawner.MaxWidth = spawner.Width;
            spawner.MaxDeep = spawner.Deep;
            spawner.NumberOfCubes = (spawner.Width*spawner.Deep)*spawner.Height;
        
        }
            
    }  
}
