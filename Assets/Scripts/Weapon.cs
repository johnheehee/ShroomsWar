using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator anim;
    public Rigidbody2D Mushmom;

    // Update is called once per frame

    private void Start()
    {
        Mushmom = GetComponent<Rigidbody2D>();
        anim = Mushmom.GetComponent<Animator>();
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.L) && anim.GetCurrentAnimatorStateInfo(0).IsTag("Crouch") == false) {
                Shoot();
            }
        }
    
    void Shoot ()
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
