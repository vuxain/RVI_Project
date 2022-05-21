using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    // public float sensX;
    // public float sensY;
    
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void Update()
    {
    
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        Vector3 correction = new Vector3(-10f, -2f, 1f);
        Vector3 cameraPosition = portal.position - playerOffsetFromPortal;

        transform.position = cameraPosition;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(-angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newForward = new Vector3(playerCamera.forward.x * -1.0f,playerCamera.forward.y,playerCamera.forward.z * -1.0f)  ;
        Vector3 newCameraDirection = portalRotationalDifference * newForward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection,Vector3.up);
    }
}
