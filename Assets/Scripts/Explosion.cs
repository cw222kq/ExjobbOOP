using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Explosion : MonoBehaviour
{
    public bool hasExplode = false;
    public GameObject spherePrefab;
    private GameObject sphereObj;
    public float delay = 3f; 
    public bool hasExplosionObject;
    private float spherePrefabYvalue;
   public void Explode (Spawner spawner)
    {
        // If sphere doesńt exist add it
        if(!hasExplosionObject)
        {
            // Spawn a sphere object in the middle of the cube structure
            sphereObj = Instantiate(spherePrefab); 
            sphereObj.transform.position = new Vector3(((float)spawner.GetMaxWidth()-1)/2, 0, ((float)spawner.GetMaxDeep()-1)/2);

            // Set the scale of the sphere
            sphereObj.transform.localScale = new Vector3(1, 1, 1);

            // Make sure that this if statement only gets executed once
            hasExplosionObject = true;

        }
        // If sphere exist make it grow
        if(hasExplosionObject)
        {
            // Increase the size of the sphere and move it upwards so it's placed on the ground while growing
            sphereObj.transform.position = new Vector3(((float)spawner.GetMaxWidth()-1)/2, spherePrefabYvalue, ((float)spawner.GetMaxDeep()-1)/2);
            float increaseValue = 0.15f;
            Vector3 increase = new Vector3(increaseValue, increaseValue, increaseValue);
            sphereObj.transform.localScale = sphereObj.transform.localScale + increase;
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
