using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference to our Focal-Point CameraRig 
    private GameObject focalPoint;

    private Rigidbody playerRb;

    public bool hasPowerUp = false;

    //Speed Configs 
    public float speed;
    //Inputs
    private float verticalInput;


    // Start is called before the first frame update
    void Start()
    {
        //Initalize players rigidbody 
        playerRb = GetComponent<Rigidbody>();

        // Intializes our reference to focalpoint script in cameraRig
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //Axis Input
        verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
        

    }
    //  Detect Collision with Power
    //  hasPowerUp == true
    //  Destory PowerUp gameObject
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Debug.Log("power up");
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
    }
}
