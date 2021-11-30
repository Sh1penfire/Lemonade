using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followObject : MonoBehaviour
{
    Camera camera;
    public Rigidbody2D rigidbody;
    public float smoothMin = 0.5f;
    public float smoothAmount = 0.02f;
    public float cameraZ;
    Vector3 moveVector;
    Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        moveVector = new Vector3();
        targetVector = new Vector3();
        camera = GetComponent<Camera>();

    }

// Update is called once per frame
    void Update()
    {
        moveVector.Set(transform.position.x, transform.position.y, cameraZ);
        targetVector.Set(rigidbody.position.x, rigidbody.position.y, cameraZ);

        moveVector = Vector3.Lerp(moveVector, targetVector, smoothAmount * Time.deltaTime);
        moveVector.x -= transform.position.x;
        moveVector.y -= transform.position.y;
        moveVector.z -= transform.position.z;

        transform.position += moveVector;
        Debug.Log(moveVector);
        Debug.Log(targetVector);
        Debug.Log(transform.position);
    }
}

