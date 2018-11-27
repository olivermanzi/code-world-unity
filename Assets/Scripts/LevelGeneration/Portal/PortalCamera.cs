using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    public Material mat;

    private void Start()
    {
        Camera cam = gameObject.GetComponent<Camera>();
   
        cam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mat.mainTexture = cam.targetTexture;
    }

    // Update is called once per frame
    void Update () {
        Vector3 offset = playerCamera.position - otherPortal.position;
        transform.position = portal.position - offset;

        float angularDiffInPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationDiff = Quaternion.AngleAxis(angularDiffInPortalRotations, Vector3.up);
        Vector3 newCameraDir = portalRotationDiff * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);
	}
}
