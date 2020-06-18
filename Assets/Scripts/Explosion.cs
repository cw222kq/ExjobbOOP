using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public bool hasExplode = false;
    public GameObject spherePrefab;
    private GameObject sphereObj;
    public float delay = 3f; 
    private bool hasExplosionObject;
    private float spherePrefabYvalue;

   public void Explode (Spawner spawner)
    {
        // If sphere doesńt exist add it
        if(!hasExplosionObject)
        {
            // Instantiate the sphere object
            sphereObj = Instantiate(spherePrefab); 

            // Set the position of the sphere object to be placed in the middle of the cube structure
            sphereObj.transform.position = new Vector3(((float)spawner.GetMaxWidth()-1)/2, 0, ((float)spawner.GetMaxDeep()-1)/2);

            // Set the scale of the sphere
            sphereObj.transform.localScale = new Vector3(1, 1, 1);

            // Make sure that this if statement only gets executed once
            hasExplosionObject = true;

        }
        
        // If sphere exist make it grow
        if(hasExplosionObject)
        {
            // Increase the size of the sphere and move it upwards so it will result in an up force of the explosion
            sphereObj.transform.position = new Vector3(((float)spawner.GetMaxWidth()-1)/2, spherePrefabYvalue, ((float)spawner.GetMaxDeep()-1)/2);

            // Set the value that the sphere will increase within every round in the loop
            float increaseValue = 0.15f;
            Vector3 increase = new Vector3(increaseValue, increaseValue, increaseValue);

            // The increase of the transform.localScale will increase the SphereCollider radius automatically to fit the transform.localScale
            // By setting the radius of the SphereColldier to 1 in the inspector the collider will always be twice as big as the rendered sphere (just as it is in the DOD/DOTS version)
            sphereObj.transform.localScale = sphereObj.transform.localScale + increase;

            // Set the value that the y position of the sphere will increase within every round in the loop
            spherePrefabYvalue += increaseValue; 

            // If the radius of the sphere is equal to or more than the maxWidth of the cube the explosion ends
            if(sphereObj.transform.localScale.x >= (float)spawner.GetMaxWidth())
            {
                // Set hasExplode to true so this explode method only gets executed once
                hasExplode = true;

                // Remove the sphere object
                Destroy(sphereObj);
            }

        }

    } 

}
