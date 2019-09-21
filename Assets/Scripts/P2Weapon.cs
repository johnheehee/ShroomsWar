using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator anim;
    public Rigidbody2D Mushmom;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && anim.GetCurrentAnimatorStateInfo(0).IsTag("Crouch") == false)
        {
            Shoot();
        }
            
    }

    void Shoot ()
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
