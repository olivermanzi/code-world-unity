using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraManager : MonoBehaviour {

    public GameObject[] environmentObjects;
    public Transform player;

    private GameObject[] cameras;

    public void Start()
    {
        cameras = GameObject.FindGameObjectsWithTag("BackwardPortalCam");
        if (cameras.Length != 3)
        {
            Debug.Log("Not enough cameras chief");
        }
        cameras[1].GetComponent<PortalCamera>().playerCamera = cameras[0].transform;
        cameras[2].GetComponent<PortalCamera>().playerCamera = cameras[1].transform;

    }

    public void Update()
    {
        if(environmentObjects[0] != null)
        {
            environmentObjects[0].transform.Find("DoorwayWall Back/Doorway/PortalTeleporter").GetComponent<Portal>().CloseGate();
        }
    }

    //Fire the entire camera rotation, call on teleport and fast-travel
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

    //Loop through connections 2 layer deep, walling off exits and setting observers
    private void EnableCorrectCameras(Transform playerLocation)
    {
        GameObject[] directConnections = GetConnections(playerLocation);
        foreach (var directCon in directConnections)
        {
            WallOffDestination(directCon);
            SetObserverCamera(directCon, player.transform.GetChild(0));
            GameObject[] indirectConnections = GetConnections(directCon.transform);
            foreach (var indirectCon in indirectConnections)
            {
                WallOffDestination(directCon);
                SetObserverCamera(indirectCon, directCon.transform.Find("PortalCamera"));
            }
        }
        RotateBackPortalCameras();
    }

    //Take away the blockade wall from exit
    private void WallOffDestination(GameObject connection)
    {
        for (int i = 0; i < connection.transform.childCount; i++)
        {
            var conn = connection.transform.GetChild(i);
            if (conn.CompareTag("BackDoorEntry")){
                var connPortal = conn.GetComponentInChildren<Portal>();
                if (!connPortal.isCorridor && connPortal.wallBelow != null)
                { 
                    connPortal.OpenGate();
                }
            }
        }
    }

    //Get a list of all the rooms the target location has connections to
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

    //Sets the camera to which all connections' portal cameras relate their movement to
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

    //There are 3 portal cameras in the scene to ensure smooth view throughout the map, rotated one after the other
    private void RotateBackPortalCameras()
    {
        var portalHistory = player.GetComponent<PortalHistory>();
        if(portalHistory.History.Count != 0)
        {
            var camOne = cameras[0].GetComponent<PortalCamera>();
            var lastPortal = portalHistory.GetLastPortalEntered().transform;
            SetupBackPortalCamera(camOne, lastPortal);

            if(portalHistory.History.Count >= 2)
            {
                var camTwo = cameras[1].GetComponent<PortalCamera>();
                var secondToLastPortal = portalHistory.GetSecondToLastPortalEntered().transform;
                SetupBackPortalCamera(camTwo, secondToLastPortal);
            }

            if (portalHistory.History.Count >= 3)
            {
                var camThree = cameras[2].GetComponent<PortalCamera>();
                var thirdToLastPortal = portalHistory.GetThirdToLastPortalEntered().transform;
                SetupBackPortalCamera(camThree, thirdToLastPortal);
            }
        }
    }

    private void SetupBackPortalCamera(PortalCamera cam, Transform portal)
    {
        cam.portal = portal.parent.Find("Portal");
        cam.otherPortals.Clear();
        cam.OtherPortal = portal.GetComponent<Portal>().receiver.parent.Find("Portal");
        portal.GetComponent<Portal>().receiver.GetComponent<BackwardPortal>().attachedCamera = cam.transform;
        SetObserverCamera(portal.parent.parent.parent.gameObject, cam.transform);

        GameObject[] indirectConnections = GetConnections(portal.parent.parent.parent);
        foreach (var indirectCon in indirectConnections)
        {
            SetObserverCamera(indirectCon, cam.transform);
        }
    }
}
