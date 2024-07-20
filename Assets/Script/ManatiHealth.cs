using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManatiHealth : MonoBehaviour
{
    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] int maxLife = 3;
    [SerializeField] int life = 3;
    [SerializeField] public bool isDeath = false;
    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();
        circleCollider2D=GetComponent<CircleCollider2D>();
        life = maxLife;
    }
    private void ChangeLife()
    {
        life--;
        if (life <=0 && isDeath==false)
        {
            isDeath = true;
            Destroy(circleCollider2D);
            Destroy(rb2D);
            Destroy(gameObject, 5);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard") && isDeath == false)
        {
            ChangeLife();
        }
    }
}
