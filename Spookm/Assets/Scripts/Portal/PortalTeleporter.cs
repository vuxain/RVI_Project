using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{

    public Transform player;
    public Transform reciever;
    public Transform portal;
    public Camera m_MainCamera;

    private bool playerIsOverlapping = false;
    private int loopCounter;
    private Transform portalPlane;
    private Transform portalPlaneCollider;
    private Transform recieverPlane;
    private GameObject foldedCurtain;
    private GameObject unfoldedCurtain;

    void Start()
    {
        loopCounter = 1;
        recieverPlane = reciever.transform.Find("RenderPlaneB");
        portalPlane = portal.transform.Find("RenderPlaneA");
        portalPlaneCollider = portal.transform.Find("RenderPlaneACol");
        foldedCurtain = GameObject.Find("Folded Curtain");
        unfoldedCurtain = GameObject.Find("Unfolded Curtain");

        foldedCurtain.SetActive(false);
        unfoldedCurtain.SetActive(true);
    }

    void Update()
    {
        if (playerIsOverlapping == true)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            CameraMovement cm = m_MainCamera.GetComponent<CameraMovement>();

            if (dotProduct < 0f)
            {
                float rotationDiff = Quaternion.Angle(player.rotation, recieverPlane.rotation) + 180;
                cm.Flip();

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = recieverPlane.position + positionOffset;

                playerIsOverlapping = false;

                if (loopCounter == 3)
                {
                    portalPlane.GetComponent<MeshRenderer>().enabled = false;
                    portalPlane.GetComponent<MeshCollider>().enabled = false;
                    portalPlaneCollider.GetComponent<PortalTeleporter>().enabled = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
            loopCounter += 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
            foldedCurtain.SetActive(true);
        }
    }
}
