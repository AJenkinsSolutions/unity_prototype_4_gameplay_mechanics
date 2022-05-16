using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference to our Focal-Point CameraRig 
    private GameObject focalPoint;
    private Rigidbody playerRb;
   

    public bool hasPowerUp = false;
    private float powerUpStrength = 8f;
    private float powerUpDuration = 8f;

    public GameObject powerUpIndicator;

    public float speed;
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
        // Move in the direction of the focal point
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
        powerUpIndicator.transform.position = transform.position + new Vector3(0.0f, -0.5f, 0.0f);

    }

    //  Detect Collision with Power
    //  hasPowerUp == true
    //  Destory PowerUp gameObject
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            powerUpIndicator.SetActive(true);
            Debug.Log("power up");
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }


    public IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {

            Debug.Log("Player Collided with " + collision.gameObject.name + "Player hasPowerUp:" + hasPowerUp);

            // DUE to collision we can now tap into that collisions GameObject
            // Giving us access to Its components
            // Therefore giving us the ability to apply forces etc to its components
            // In theroy we could access that gameObjects Script
            // Giving us access to its variables 
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            // Vector Math: Direction opposite (away) the player postion
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            //ADDING FORCE: awayFromPlayer
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);



        }
    }
}
