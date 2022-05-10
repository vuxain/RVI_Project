using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{

    public Transform player;
    public Transform reciever;

    private bool playerIsOverlapping = false;

    void Update()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up,portalToPlayer);

            if(dotProduct < 0f) // Player passed through the portal
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation,reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up,rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f,rotationDiff,0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerIsOverlapping = false;
            }
        }
    }

    void onTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAA");
        }
    }

    void onTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAA");
        }
    }
}
