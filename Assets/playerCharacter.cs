using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCharacter : MonoBehaviour
{
    private Vector2 movementMultiplier = new Vector2(0, 0);
    Vector2 vel = new Vector2();
    Rigidbody2D rigidbody;
    public float moveSpeed;
    public float drag;
    public Rigidbody2D currentGrenade;
    public Vector2 grenadeMovementMultiplier;
    private Vector2 v1 = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.drag = drag;
    }

    // Update is called once per frame
    void Update()
    {
        vel.Set(0, 0);
        movementMultiplier.Set(1, 1);
        bool keyDown = false;
        if (Input.GetKey(KeyCode.A))
        {
            movementMultiplier.y /= 2;
            vel.x -= moveSpeed;
            keyDown = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementMultiplier.y /= 2;
            vel.x += moveSpeed;
            keyDown = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementMultiplier.x /= 2;
            vel.y -= moveSpeed;
            keyDown = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movementMultiplier.x /= 2;
            vel.y += moveSpeed;
            keyDown = true;
        }
        vel.x *= movementMultiplier.x;
        vel.y *= movementMultiplier.y;

        if (keyDown) {
            //float length = Mathf.Sqrt(vel.x + vel.y);

            rigidbody.AddForce(vel);

            if (rigidbody.velocity.magnitude > 5)
            {
                Vector2 normalized = rigidbody.velocity.normalized;
                normalized.x *= 5;
                normalized.y *= 5;
                rigidbody.velocity.Set(normalized.x, normalized.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            var grenade = Instantiate(currentGrenade, transform.position, transform.rotation);
            v1.Set(rigidbody.velocity.x, rigidbody.velocity.y);
            v1.Scale(grenadeMovementMultiplier);
            grenade.AddForce(v1);
            Debug.Log(v1);
        }
    }
}
