using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public static float health = 2.4f;
    public GameObject deathEffect;
    public Transform Mushmom;
    public Transform spawnPoint;
    public static Enemy2 mm;
    public Rigidbody2D mushmom;
    public Animator anim;
    public static int lives;
    public GameObject heart1, heart2, heart3, emptyheart1, emptyheart2, emptyheart3,youwin,character;

    void Start()
    {
            lives = 3;
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            emptyheart1.gameObject.SetActive(true);
            emptyheart2.gameObject.SetActive(true);
            emptyheart3.gameObject.SetActive(true);
            youwin.gameObject.SetActive(false);
            character.gameObject.SetActive(false);
       }
        void Update()
        {
            if (lives > 3)
                lives = 3;
            switch (lives)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                youwin.gameObject.SetActive(true);
                character.gameObject.SetActive(true);
                FindObjectOfType<SoundEffects>().VictorySound();
                Time.timeScale = 0;
                break;
        }
            if (mm == null)
        {
            mm = GameObject.FindGameObjectWithTag("Mushmom2").GetComponent<Enemy2>();
            mushmom = GetComponent<Rigidbody2D>();
            anim = mushmom.GetComponent<Animator>();
        }
    }

    public void TakeDamage(float damage)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Crouch") == false) {
            health -= damage;
            if (null != anim)
            {
                SoundManagerScript.PlaySound ("playerHit");
                anim.Play("BMushmom_Hit");
            }
        }
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        mushmom.transform.position = spawnPoint.position;
        health = 2.4f;
        lives -= 1;
        Destroy(GameObject.Find("deathEffect(Clone)"), 2);
        //Destroy(gameObject);
    }

    /*public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Bullet1")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }*/
}

