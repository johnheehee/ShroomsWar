using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float damage = 0.2f;
    public float lifeTime;
    public GameObject destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Physics2D.IgnoreLayerCollision(8, 9);
        Invoke("DestroyProjectile", lifeTime);
    }

    void Update()
    {
        Destroy(GameObject.Find("ImpactEffect(Clone)"));
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy2 enemy = hitInfo.GetComponent<Enemy2>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
       Destroy(gameObject);
        Destroy(GameObject.Find("ImpactEffect(Clone)"), 2);
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
    // Update is called once per frame

