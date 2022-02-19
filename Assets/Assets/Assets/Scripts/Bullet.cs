using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;
    [SerializeField]
    public int damage = 20;
    public Rigidbody2D rb;
    public Enemy enemy;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemy = GameObject.Find(other.gameObject.name).GetComponent<Enemy>();
            enemy.takeDamage(damage);
        }
        if (other.gameObject.name != "Bullet(Clone)" && other.gameObject.tag != "Mushroom")
        {
            Destroy(this.gameObject);
        }
    }


}
