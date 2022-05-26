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

    private GameObject decals1;
    private GameObject decals2;
    private GameObject decals3;

    private Transform hallLightSource1;
    private Transform hallLightSource2;
    private Transform hallLightSource3;

    void Start()
    {
        loopCounter = 1;
        recieverPlane = reciever.transform.Find("RenderPlaneB");
        portalPlane = portal.transform.Find("RenderPlaneA");
        portalPlaneCollider = portal.transform.Find("RenderPlaneACol");
        foldedCurtain = GameObject.Find("Folded Curtain Portal");
        unfoldedCurtain = GameObject.Find("Unfolded Curtain Portal");

        decals1 = GameObject.Find("RedTapeDecals lvl1");
        decals2 = GameObject.Find("RedTapeDecals lvl2");
        decals3 = GameObject.Find("RedTapeDecals lvl3");

        hallLightSource1 = GameObject.Find("Ceiling Light 4").transform.Find("Point Light");
        hallLightSource2 = GameObject.Find("Ceiling Light 5").transform.Find("Point Light");
        hallLightSource3 = GameObject.Find("Ceiling Light 6").transform.Find("Point Light");


        recieverPlane.GetComponent<MeshCollider>().enabled = false;
        foldedCurtain.SetActive(false);
        unfoldedCurtain.SetActive(true);
        decals1.SetActive(true);
        decals2.SetActive(false);
        decals3.SetActive(false);
        hallLightSource1.transform.GetComponent<LightFlickerControl>().enabled = false;
        hallLightSource2.transform.GetComponent<LightFlickerControl>().enabled = false;
        hallLightSource3.transform.GetComponent<LightFlickerControl>().enabled = false;
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
                float rotationDiff = Quaternion.Angle(player.rotation, recieverPlane.rotation);
                cm.Flip();

                //Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer + new Vector3(-0.65f, 0f, 0f);
                Vector3 positionOffset = portalToPlayer + new Vector3(-0.65f, 0f, 0f);
                player.position = recieverPlane.position + new Vector3(positionOffset.x, positionOffset.y, positionOffset.z * -1f);

                playerIsOverlapping = false;
                recieverPlane.GetComponent<MeshCollider>().enabled = true;

                if (loopCounter > 1)
                {
                    hallLightSource1.transform.GetComponent<LightFlickerControl>().enabled = true;
                    hallLightSource2.transform.GetComponent<LightFlickerControl>().enabled = true;
                    hallLightSource3.transform.GetComponent<LightFlickerControl>().enabled = true;
                }

                if (loopCounter == 2)
                {
                    decals2.SetActive(true);
                }

                if (loopCounter == 3)
                {
                    decals3.SetActive(true);
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

    public void disableCurtain()
    {
        foldedCurtain.SetActive(false);
    }
}
