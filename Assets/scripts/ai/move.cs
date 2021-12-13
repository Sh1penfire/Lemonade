using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;

    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();

    }

    void Update(){
        
    }
}