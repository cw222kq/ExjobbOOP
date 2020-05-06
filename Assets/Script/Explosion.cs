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

   public void Explode (Spawner spawner)
    {
        Debug.Log("BOOM");
        hasExploded = true;
        GameObject sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
        sphereObj.transform.localScale = new Vector3(1,1,1); 
        sphereObj.transform.position = new Vector3((spawner.GetMaxWidth()-1)/2,0,(spawner.GetMaxDeep()-1)/2);
        //Instantiate(explosionEffect, sphereObj.transform.position, sphereObj.transform.rotation);
        sphereObj.GetComponent<Renderer>().enabled = false;
        sphereObj.GetComponent<Collider>().enabled = false;
        Vector3 explosionPosition = sphereObj.transform.position;
    
        // Set force on nearby objects. Defines a shpere on the given position. The method returns an array with all the colliders overlapping with the sphere.
        Collider[] collidersToDestroy = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider nearbyObj in collidersToDestroy) {
           
             // Add force on the colliders that has a ridgidbody.
            Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();
            if (rb) 
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);
            }
            
        }

        Destroy(sphereObj);

    } 

}
