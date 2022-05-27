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

    private GameObject portalB;
    private Transform recieverPlane;

    void Start()
    {
        portalB = GameObject.Find("PortalB");
        recieverPlane = portalB.transform.Find("RenderPlaneB");
    }

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
            recieverPlane.GetComponent<MeshCollider>().enabled = false;
            GameObject.Find("PortalA").transform.Find("RenderPlaneACol").GetComponent<PortalTeleporter>().disableCurtain();
            portalB.SetActive(false);
        }

        if (verticalMovement == true)
        {
            enemy.position = enemy.position + new Vector3(0, -40f, 0) * Time.deltaTime;
        }

        if (horizontalMovement == true)
        {
            enemy.position = enemy.position + new Vector3(0, 0, 40f) * Time.deltaTime;
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
