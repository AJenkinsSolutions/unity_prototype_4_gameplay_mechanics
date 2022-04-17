using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followplayer : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerCont;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerCont = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce((playerCont.transform.position - enemyRb.transform.position).normalized * speed);
    }
}
