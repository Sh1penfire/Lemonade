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
    float moveAmount = 0, moveOffset = 0;

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
        
        //set the move amount and target position
        moveVector.Set(transform.position.x, transform.position.y, cameraZ);
        targetVector.Set(rigidbody.position.x, rigidbody.position.y, cameraZ);

        //lerp move amount, then remove to find offset and add that
        moveVector = Vector3.Lerp(moveVector, targetVector, smoothAmount * Time.deltaTime);
        moveVector.x -= transform.position.x;
        moveVector.y -= transform.position.y;
        moveVector.z -= transform.position.z;

        transform.position += moveVector;

        //minimum move amount for x
        moveOffset = rigidbody.position.x - targetVector.x;
        moveAmount = moveOffset > 1 ? smoothMin : -smoothMin;

        moveVector.x = Mathf.Clamp(moveAmount, moveOffset, -moveOffset);

        //minimum move amount for y
        moveOffset = rigidbody.position.y - targetVector.y;
        moveAmount = moveOffset > 1 ? smoothMin : -smoothMin;

        moveVector.x = Mathf.Clamp(moveAmount, moveOffset, -moveOffset);

        //add minimum move amount
        transform.position += moveVector;
    }
}

