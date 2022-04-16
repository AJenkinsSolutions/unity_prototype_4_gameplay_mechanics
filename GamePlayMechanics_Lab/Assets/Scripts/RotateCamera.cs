using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private Rigidbody focalPointRb;

    private float horizontalInput;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        focalPointRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    

        transform.Rotate(0.0f, 90.0f * speed * Time.deltaTime * horizontalInput, 0.0f);
        

        
    }
}
