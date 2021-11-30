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
    // Start is called before the first frame update
    void Start()
    {
        time = 0;

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

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position2D, explosionRadius, 0);

        Debug.Log(position2D);

        foreach (Collider2D collider in colliders){
            Rigidbody2D rigidbody = collider.GetComponent<Rigidbody2D>();
            if (rigidbody != null) {
                rigidbody.AddForce(new Vector2(1, 1));
            }
            Debug.Log(rigidbody);
        }
        Destroy(gameObject);
    }
}
