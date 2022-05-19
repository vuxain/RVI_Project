using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{

    public Transform player;
    public Transform reciever;
    public Camera m_MainCamera;

    private bool playerIsOverlapping = false;


    void Update()
    {
        if (playerIsOverlapping == true)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            CameraMovement cm = m_MainCamera.GetComponent<CameraMovement>();

            if (dotProduct < 0f)
            {
                float rotationDiff = Quaternion.Angle(player.rotation, reciever.rotation) + 180;
                cm.Flip();

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerIsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
