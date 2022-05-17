using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerScript : MonoBehaviour
{

    public Transform player;
    public Transform enemy;

    private bool verticalMovement = false;
    private bool horizontalMovement = false;

    void Update()
    {
        if (enemy.position.z > 40.0f)
        {
            verticalMovement = true;
            horizontalMovement = false;
        }

        if (enemy.position.y < 11.2f)
        {
            verticalMovement = false;
        }

        if (verticalMovement == true)
        {
            enemy.position = enemy.position + new Vector3(0, -0.4f, 0);
        }

        if (horizontalMovement == true)
        {
            enemy.position = enemy.position + new Vector3(0, 0, 0.3f);
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
