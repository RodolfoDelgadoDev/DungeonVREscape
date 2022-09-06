using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossesMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float velocity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.forward * velocity;
    }
}
