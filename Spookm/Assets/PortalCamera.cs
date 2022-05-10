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

    public Transform orientation;


    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position - playerOffsetFromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(-angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newForward = new Vector3(playerCamera.forward.x * -1.0f,playerCamera.forward.y,playerCamera.forward.z * -1.0f)  ;
        Vector3 newCameraDirection = portalRotationalDifference * newForward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection,Vector3.up);
        


    }
}
