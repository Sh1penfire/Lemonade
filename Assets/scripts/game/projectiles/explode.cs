using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public ParticleSystem explosionEffect;
    public float explosionTime;
    public float explosionRadius;
    private float time;
    private Vector2 position2D;
    private Collider2D[] results;
    private ContactFilter2D filter = new ContactFilter2D();
    // Start is called before the first frame update
    void Start()
    {

        time = 0;
        results = new Collider2D[100];
        filter.NoFilter();

    }

    // Update is called once per frame
    void Update()
    {
        position2D.x = transform.position.x;
        position2D.y = transform.position.y;
        time += Time.deltaTime;
        if (time >= explosionTime) {
            Explode();
        }
    }

    void Explode(){
        Instantiate(explosionEffect, transform.position, transform.rotation);

        int collided = Physics2D.OverlapCircle(position2D, explosionRadius, filter, results);

        if(collided > 1) foreach (Collider2D collider in results)
        {
            Rigidbody2D rigidbody = collider.GetComponent<Rigidbody2D>();
            if (rigidbody != null) {
                rigidbody.AddForce(new Vector2(1, 1));
            }
            Debug.Log(rigidbody);
        }
        Destroy(gameObject);
    }
}
