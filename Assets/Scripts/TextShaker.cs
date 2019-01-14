using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShaker : MonoBehaviour {

    RectTransform textRect;
    Vector2 defaultPos;

    public float amount = .02f; //Deviation on the x axis
    public float rate = 0.001f; //The speed

    private float upperLimit;
    private float lowerLimit;
    bool isGoingForward = true;

	// Use this for initialization
	void Start () {
        textRect = GetComponent<RectTransform>();
        defaultPos = textRect.pivot;
        lowerLimit = defaultPos.x;
        upperLimit = lowerLimit + amount;
    }

    // Update is called once per frame
    void Update () {

        //Move text in direction by the rate each frame
        if(textRect.pivot.x < upperLimit && isGoingForward)
        {
            textRect.pivot = new Vector2(textRect.pivot.x+rate, defaultPos.y);
        }
        else if(textRect.pivot.x > lowerLimit && !isGoingForward)
        {
            textRect.pivot = new Vector2(textRect.pivot.x-rate, defaultPos.y);
        }
        //Change direction if limit is reached
        else
        {
            isGoingForward = !isGoingForward;
        }
    }
}
