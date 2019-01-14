using UnityEngine;

public class Portal : MonoBehaviour {

    private Transform _receiver;
    public Transform receiver
    {
        get{ return _receiver; }
        set
        {
            _receiver = value;
        }
    } 

    public string destinationString;
    public Transform destination;

	private Transform player;
	private Transform attachedCamera;
    private PortalCameraManager portalCameraManager;
    public Transform wallBelow;
    private Transform _text;
	private bool isOverlapping = false;
    private bool isBackwardPortal = false;
    public bool isCorridor = false;
    private float _teleportTimer = 0.0f;


    private void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		attachedCamera = transform.parent.parent.parent.Find("PortalCamera").transform;
        portalCameraManager = GameObject.Find("PortalCameraManager").GetComponent<PortalCameraManager>();
        isBackwardPortal = transform.parent.parent.CompareTag("BackDoorEntry") ? true : false;

        if (isBackwardPortal)
        {
            gameObject.AddComponent<BackwardPortal>();
        }

        if(transform.parent.parent.parent.GetComponent<Corridor>() != null)
        {
                isCorridor = true;
        }
        else
        {
            wallBelow = transform.parent.parent.Find("WallBelow");
            wallBelow.gameObject.SetActive(false);
            _text = transform.parent.parent.Find("WallAbove/Text");
        }

        if(receiver != null)
        {
            destination = receiver.transform.parent.parent.parent.Find("PortalCamera").transform;
        }
        if(destination == null && !isCorridor && !isBackwardPortal)
        {
            CloseGate();
        }
    }

    // Update is called once per frame
    void Update () 
	{
        if (isOverlapping == true  )
        {
            player.GetComponent<FirstPersonController>().isTeleporting = true;
			TeleportPlayer ();
			isOverlapping = false;
            player.GetComponent<FirstPersonController>().isTeleporting = false;

        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            isOverlapping = true;
        }
    }

	private void TeleportPlayer()
	{
        var history = player.GetComponent<PortalHistory>();
        Transform destination = null;
        if (isBackwardPortal)
        {
            //Get the portal we're supposed to TP to and remove it from history
            destination = GetComponent<BackwardPortal>().attachedCamera;
            if (!history.GetLastPortalEntered().Equals(transform))
            {
                receiver = history.PopLastPortalEntered().transform;
            }
        }
        else
        {
            destination = receiver.transform.parent.parent.parent.Find("PortalCamera").transform;
        }
        Vector3 destinationRot = destination.transform.rotation.eulerAngles;
		Vector3 portalToPlayer = player.position - transform.position;
		float dotProduct = Vector3.Dot(transform.parent.Find("Portal").up, portalToPlayer);
		//If Player entered portal through front
		if (dotProduct < 1f) {

            //Teleport player and adjust rotations
            player.transform.forward = destination.forward;
            player.transform.up = destination.up;
            player.transform.position = destination.position;
            player.GetComponent<FirstPersonController>().RotateTowards(destinationRot);

            //Only add to history if we aren't going through a Back portal
            if (!isBackwardPortal)
            {
                history.History.Add(gameObject);
            }

            //Adjust portal cameras
            portalCameraManager.CycleCameras();
        }
    }

    public void CloseGate()
    {
        wallBelow.gameObject.SetActive(true);
        _text.gameObject.SetActive(false);
    }

    public void OpenGate()
    {
        wallBelow.gameObject.SetActive(false);
         _text.gameObject.SetActive(true);
    }
}