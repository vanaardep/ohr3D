 using UnityEngine;
 using System.Collections;
 
 public class PlayerShooting : MonoBehaviour {
 
     public Rigidbody2D bulletPrefab;
     public float attackSpeed = 0.5f;
     public float coolDown;
     public float bulletSpeed = 500;
     public float yValue = 1f; // Used to make it look like it's shot from the gun itself (offset)
     public float xValue = 0.2f; // Same as above
 
     
     // Update is called once per frame
     void Update () 
     {
     
         if(Time.time >= coolDown)
         {
             if(Input.GetMouseButton(0))
             {
                 Fire();
             }
         }
     }
 
     void Fire()
     {
        /* //Rigidbody2D bPrefab = Instantiate(bulletPrefab,transform.position,Quaternion.identity) as Rigidbody2D;
 
         Rigidbody2D bPrefab = Instantiate(bulletPrefab, new Vector3(transform.position.x + xValue, transform.position.y + yValue, transform.position.z), Quaternion.identity) as Rigidbody2D;
 
         bPrefab.rigidbody2D.AddForce(Vector2.up * bulletSpeed);
             // bPrefab.rigidbody2D.AddForce(transform.up * bulletSpeed); //or
 
         coolDown = Time.time + attackSpeed; */
     }
 }