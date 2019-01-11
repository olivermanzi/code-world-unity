using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraManager : MonoBehaviour {

    public GameObject[] environmentObjects;
    public Transform player;

    public void CycleCameras()
    {
        Transform playerLocation = null;
        foreach (var item in environmentObjects)
        {
            //Deactivate Cameras
            item.transform.Find("PortalCamera").gameObject.SetActive(false);
            //Find which room the player is in
            if (player.transform.position.y - item.transform.position.y < 15f && player.transform.position.y - item.transform.position.y > 10f)
            {
                playerLocation = item.transform;
            }
        }
        if(playerLocation != null)
        {
            EnableCorrectCameras(playerLocation);
        }
    }

    private void EnableCorrectCameras(Transform playerLocation)
    {
        GameObject[] directConnections = GetConnections(playerLocation);
        foreach (var directCon in directConnections)
        {
            SetObserverCamera(directCon, player.transform.GetChild(0));
            GameObject[] indirectConnections = GetConnections(directCon.transform);
            foreach (var indirectCon in indirectConnections)
            {
                SetObserverCamera(indirectCon, directCon.transform.Find("PortalCamera"));
            }
        }
        RotateBackPortalCameras();
    }

    private GameObject[] GetConnections(Transform location)
    {
        GameObject[] connections = null;
        if (location.GetComponent<RoomBehaviour>() != null)
        {
            var loc = location.GetComponent<RoomBehaviour>();
            connections = loc.subrooms.ToArray();
        }
        else
        {
            var loc = location.GetComponent<Corridor>();
            connections = loc.Connections.ToArray();
        }
        return connections;
    }

    private void SetObserverCamera(GameObject location, Transform newCamera)
    {
        var camera = location.transform.Find("PortalCamera").GetComponent<PortalCamera>();
        camera.playerCamera = newCamera;
        foreach (var item in camera.otherPortals)
        {
            foreach (var mr in location.transform.GetComponentsInChildren<MeshRenderer>())
            {
                if (item.Equals(mr))
                {
                    camera.OtherPortal = mr.transform;
                }
            }
        }
        camera.gameObject.SetActive(true);
    }

    //There's 3 portal cameras in the scene to ensure smooth view throughout the map, rotated one after the other

    private int cameraCounter = 0;
    private void RotateBackPortalCameras()
    {
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("BackwardPortalCam");
        if (cameras.Length != 3)
        {
            Debug.Log("Not enough cameras chief");
        }
        var portalHistory = player.GetComponent<PortalHistory>();
        if(portalHistory.History.Count != 0)
        {
           
                if (cameraCounter == cameras.Length - 1) { cameraCounter = 0; }

                var nextCam = cameras[0].GetComponent<PortalCamera>();
                var lastPortal = portalHistory.GetLastPortalEntered().transform;
                nextCam.portal = lastPortal.parent.Find("Portal");
                nextCam.OtherPortal = lastPortal.GetComponent<Portal>().receiver.parent.Find("Portal");
            lastPortal.GetComponent<Portal>().receiver.GetComponent<BackwardPortal>().attachedCamera = nextCam.transform;
                SetObserverCamera(lastPortal.parent.parent.parent.gameObject, nextCam.transform);

                GameObject[] indirectConnections = GetConnections(lastPortal.parent.parent.parent);
                foreach (var indirectCon in indirectConnections)
                {
                    SetObserverCamera(indirectCon, nextCam.transform);
                }
        }
    }
}
