using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTriggerScript : MonoBehaviour
{

    public Transform player;
    public Transform enemy;

    private bool verticalMovement = false;
    private bool horizontalMovement = false;


    void Update()
    {
        if (enemy.position.z > 18.0f)
        {
            verticalMovement = true;
            horizontalMovement = false;
        }

        if (enemy.position.y < 4.83)
        {
            verticalMovement = false;

            enemy.GetComponent<NavMeshAgent>().enabled = true;
            enemy.GetComponent<Rigidbody>().isKinematic = true;

            enemy.GetComponent<EnemyScript>().enabled = true;            
            enemy.GetComponent<EnemyTriggerScript>().enabled = false;



        }

        if (verticalMovement == true)
        {
            enemy.position = enemy.position + new Vector3(0, -0.4f, 0);
        }

        if (horizontalMovement == true)
        {
            enemy.position = enemy.position + new Vector3(0, 0, 0.7f);
        } 
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            horizontalMovement = true;
        }
    }
}
