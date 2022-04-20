using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;

    //Declare Enemy rigidbody
    private Rigidbody enemyRb;

    //Reference to player controller script
    private GameObject playerCont;

    // Start is called before the first frame update
    void Start()
    {

        enemyRb = GetComponent<Rigidbody>();
        // Initalize Reference to player Gameobject
        playerCont = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards vector math *normalized*
        Vector3 moveDirection = (playerCont.transform.position - enemyRb.transform.position).normalized;
        // Add force in the vector look direction 
        enemyRb.AddForce(moveDirection * speed);

    }
}