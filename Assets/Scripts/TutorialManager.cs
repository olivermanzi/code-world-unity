using UnityEngine;

/// <summary>
/// Handles the display of the tutorial and the input required to control it
/// </summary>
public class TutorialManager : MonoBehaviour {

    GameObject[] tutCanvases;

    GameObject fpCanvas;

    // Find canvases
    void Start () {
        var tutCanvas1 = GameObject.Find("TutorialCanvas");
        var tutCanvas2 = GameObject.Find("TutorialCanvas2");
        tutCanvases = new GameObject[] { tutCanvas1, tutCanvas2 };

        fpCanvas = GameObject.Find("FirstPersonCanvas");
        fpCanvas.SetActive(false); //Disable fps canvas so cursor doesnt poke through
    }

    // Update is called once per frame
    void Update () {
        EnterListener();
	}

    private int canvasCounter = 0;

    private void EnterListener()
    {
        //On enter remove next in sequence tutorial canvas
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(tutCanvases[canvasCounter]);
            canvasCounter++;
            //When tutorial is done remove this GameObject from the scene and enable player UI
            if (canvasCounter >= tutCanvases.Length)
            {
                fpCanvas.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
