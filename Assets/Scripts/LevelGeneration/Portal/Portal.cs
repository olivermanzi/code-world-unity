using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    private Transform player;
    public Transform receiver;

    private bool isOverlapping = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update () {
        if (isOverlapping == true && receiver != null)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            isOverlapping = false;
            var destination = receiver.transform.parent.parent.parent.Find("PortalCamera").transform.position;
            var camrot =  receiver.transform.parent.parent.parent.Find("PortalCamera").transform.rotation;
            player.transform.position = new Vector3(destination.x, player.transform.position.y, destination.z);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            isOverlapping = true;
        }
    }
}
