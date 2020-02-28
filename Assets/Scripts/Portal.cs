using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDiffernceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDiffernceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;

        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
