using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    //Decalre our focal point rigid body 
    private Rigidbody focalPointRb;

    private float horizontalInput;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Intalize our Focal Poiunt Camera Rig
        focalPointRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Axis horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
    
        //Rotate Camera rig on horizontal input
        transform.Rotate(0.0f, 90.0f * speed * Time.deltaTime * horizontalInput, 0.0f);
        

        
    }
}
