using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
   public bool hasExploded = false;
   float power = 75f;
   float radius;
   float upforce;
   public GameObject explosionEffect;

   public void SetRadius(float value)
   {
       radius = value;
   }

   public float GetRadius() 
   {
       return radius;
   }

   public void Explode (Spawner spawner) // TODO: Write a own Explode function. Look at the Explode function in the DOD/DOTS version
    {
        Debug.Log("BOOM");
        hasExploded = true;
        // Create a sphere game object with the size 1, 1, 1
        GameObject sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
        sphereObj.transform.localScale = new Vector3(1,1,1); 
        //Instanciate the sphere in the middle of the structure of cubes
        sphereObj.transform.position = new Vector3((spawner.GetMaxWidth()-1)/2,0,(spawner.GetMaxDeep()-1)/2);
        //Instantiate(explosionEffect, sphereObj.transform.position, sphereObj.transform.rotation);
        // Disable the Renderer (makes the sphere invisable)
        sphereObj.GetComponent<Renderer>().enabled = false;
        // Disable the Collider (So it does not collide with the cubes)
        sphereObj.GetComponent<Collider>().enabled = false;
        // Set the position of the explosion the the sphere objects position
        Vector3 explosionPosition = sphereObj.transform.position;
    
        // Set force on nearby objects. Defines a shpere on the given position. The method returns an array with all the colliders overlapping with the sphere.
        Collider[] collidersToDestroy = Physics.OverlapSphere(explosionPosition, radius);
        // Add a explosion force on every object in the stated radius of the sphere object
        foreach (Collider nearbyObj in collidersToDestroy) {
           
             // Add force on the colliders that has a ridgidbody.
            Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();
            if (rb) 
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);
            }
            
        }
        // Remove the sphere object
        Destroy(sphereObj);

        // TODO: Own explode method

        // 1. If sphere doesńt exist add it

        // Spawn a sphere object in the middle of the cube structure

        // Set the position of the sphere object to be placed in the middle of the cube structure

        // Set the radius of the sphere

        // Make sure that this if statement only gets executed once


        // 2. If sphere exist make it grow

        // Increase the size of the sphere and move it upwards so it's placed on the ground while growing

        // When the radius of the sphere is equal to or more than the maxWidth of the cube the explosion ends

        // Set hasExplode to true so this explode method only gets executed once

        // Remove the sphere object



    } 

}
