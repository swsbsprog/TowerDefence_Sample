using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Vector3 destination;
    public float speed = 10;
    private void Update()
    {
        Vector3 direction = destination - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.GetComponent<Monster>();
        if (monster == null)
            return;

        Destroy(monster.gameObject);
        Destroy(gameObject);
    }
}
