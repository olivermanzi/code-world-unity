using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public Transform player;
    public Transform reciever;

    private bool isOverlapping = false;

    // Update is called once per frame
    void Update () {
        if (isOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f)*portalToPlayer;
                player.position = reciever.position + positionOffset;

                isOverlapping = false;
            }
        }
	}

    private void OnTriggerEnter(Collider collision)
    {
            isOverlapping = true;
    }
}
