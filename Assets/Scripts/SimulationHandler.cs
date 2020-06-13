﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationHandler : MonoBehaviour
{
    // Variables
    private int frames;
    private float deelay = 3f;
    private float countdown;
    
    private static Cube cube;
    private static Spawner spawner;
    private static Explosion explosion;

    void Awake() // https://www.youtube.com/watch?v=fGshe3ILKnA
    {
        cube = GetComponent<Cube>();
        spawner = GetComponent<Spawner>();
        explosion = GetComponent<Explosion>();

    }
    // Checks the user input from the GUI. If width, deep and height is set to values those values will be used to set the numberOfCubes
    // If width, deep and height are set to zero the building of cubes will consist of the value set in the numberOfCubes field
    // Every complete level will consist of 100 cubes
    void ProcessUserInput() 
    {
        if (spawner.width > 0 && spawner.deep > 0 && spawner.height > 0) 
        {
            spawner.SetMaxWidth(spawner.width);
            spawner.SetMaxDeep(spawner.deep);
            spawner.numberOfCubes = (spawner.width*spawner.deep)*spawner.height;
        
        }
        // Sets the radius on the explosion
        if(spawner.GetMaxWidth() > spawner.GetMaxDeep()) 
        {
            explosion.SetRadius(spawner.GetMaxWidth()/2);
        }
        else if(spawner.GetMaxDeep() > spawner.GetMaxWidth())
        {
            explosion.SetRadius(spawner.GetMaxDeep()/2);
        }
        else {
            explosion.SetRadius(spawner.GetMaxDeep()/2);
        } 
        
    }   
    // Start is called before the first frame update
    void Start()
    {
        ProcessUserInput();
        spawner.SpawnCubes(cube);
        // x sec after the building has been built up an explosion will occur
        countdown = deelay;
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !explosion.hasExploded) 
        {
            explosion.Explode(spawner);
        }
        // Change color of the cubes every every frame before the explosion
        if (!explosion.hasExploded) 
        {
            cube.ChangeColors(spawner.clones);
        }

        if(!explosion.hasExploded)
        {
            frames ++;
        }
        
    }
}