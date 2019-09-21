using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Bullet : MonoBehaviour
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
        Physics2D.IgnoreLayerCollision(10, 11);
        Invoke("DestroyProjectile", lifeTime);
    }
    void Update()
    {
        Destroy(GameObject.Find("ImpactEffect(Clone)"));
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
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

