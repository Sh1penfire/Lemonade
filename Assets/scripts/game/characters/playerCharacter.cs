using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCharacter : MonoBehaviour
{
    private Vector2 movementMultiplier = new Vector2(0, 0);
    Vector2 vel = new Vector2();
    Rigidbody2D rigidbody;
    public float moveSpeed;
    public float acceleration = 0;
    public float drag;
    public Rigidbody2D currentGrenade;
    public Vector2 grenadeMovementMultiplier;
    public float grenadeBaseThrowSpeed;
    private Vector2 v1 = new Vector2(), v2 = new Vector2(), v3 = new Vector2();
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
        movementMultiplier.Set(acceleration, acceleration);
        bool keyDown = false;
        if (Input.GetKey(KeyCode.A))
        {
            movementMultiplier.y /= 2;
            vel.x -= acceleration;
            keyDown = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementMultiplier.y /= 2;
            vel.x += acceleration;
            keyDown = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementMultiplier.x /= 2;
            vel.y -= acceleration;
            keyDown = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movementMultiplier.x /= 2;
            vel.y += acceleration;
            keyDown = true;
        }
        vel.x *= movementMultiplier.x;
        vel.y *= movementMultiplier.y;

        if (keyDown) {
            //float length = Mathf.Sqrt(vel.x + vel.y);

            rigidbody.AddForce(vel);

            if (rigidbody.velocity.magnitude > moveSpeed)
            {
                Vector2 normalized = rigidbody.velocity.normalized;
                normalized.x *= moveSpeed;
                normalized.y *= moveSpeed;
                rigidbody.velocity.Set(normalized.x, normalized.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            //make the grenade
            var grenade = Instantiate(currentGrenade, transform.position, transform.rotation);

            //velocity * velocity multi
            v1.Set(rigidbody.velocity.x, rigidbody.velocity.y);
            v1.Scale(grenadeMovementMultiplier);

            //base grenade velocity, rotated to the player's velocity
            v2.Set(rigidbody.velocity.x, rigidbody.velocity.y);
            v2.Normalize();
            v3.Set(grenadeBaseThrowSpeed, grenadeBaseThrowSpeed);
            v2.Scale(v3);

            //add together the forces, then make the grenade fly that fast
            v1 += v2;
            grenade.AddForce(v1);
        }

        v1.Set(Mathf.Log(2, rigidbody.velocity.x) * 2 + 1, Mathf.Log(2, rigidbody.velocity.y) * 2 + 1);
        v2.Set(v1.x - v1.y / 2, v1.y - v1.x / 2);
        transform.localScale.Scale(v1);
    }
}