using UnityEngine;
using System;

public class PortalCamera : MonoBehaviour
{
	private Transform _otherPortal;
	public Transform OtherPortal
	{
		get
		{
			return _otherPortal;
		}
		set
		{
			_otherPortal = value;
			if(_otherPortal != null)
			{
				_otherPortal.GetComponent<MeshRenderer>().material = mat;
			}
		}
	}
    public Transform playerCamera;
    public Transform portal;
    private Material mat;
    private Camera cam;

    private void Awake()
    {
        cam= gameObject.GetComponent<Camera>();
     
        var shader = Shader.Find("Unlit/ScreenCutoutShader");

        if (cam.targetTexture != null)
        {
            cam.targetTexture.Release();
        }
        cam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mat = new Material(shader);
        mat.mainTexture = cam.targetTexture;
        playerCamera = GameObject.FindWithTag("Player").transform.GetChild(0);
    }

    private void Start()
    {
        var shader = Shader.Find("Unlit/ScreenCutoutShader");

       	if (cam.targetTexture != null)
        {
            cam.targetTexture.Release();
        }
        cam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mat = new Material(shader);
        mat.mainTexture = cam.targetTexture;
        _otherPortal.GetComponent<MeshRenderer>().material = mat;
    }


    // Update is called once per frame
    void Update()
    {
        if(OtherPortal != null){
            Vector3 offset = playerCamera.position - OtherPortal.position;
			transform.position = TranslatePosition(portal.position - offset);

            float angularDiffInPortalRotations = Quaternion.Angle(portal.rotation, OtherPortal.rotation);

            Quaternion portalRotationDiff = Quaternion.AngleAxis(angularDiffInPortalRotations, Vector3.up);
            Vector3 newCameraDir = (portalRotationDiff * playerCamera.forward);

			var defaultRotation = Quaternion.LookRotation (newCameraDir, Vector3.up);
			transform.rotation = TranslateRotation(defaultRotation);
        }
    }

	//Align PortalCamera movement with player movement with regards to rotation of the OtherPortal's gateway object
    private Vector3 TranslatePosition(Vector3 defaultPosition)
    {
		Vector3 result = defaultPosition;
		var offset = playerCamera.position - OtherPortal.position;

		int otherPortalEntranceRotation = (int) OtherPortal.parent.parent.rotation.eulerAngles.y;
		if (otherPortalEntranceRotation == 90) 
		{
			var zDiff = portal.position.x - offset.z;
			var xDiff = portal.position.z + offset.x;
			result = new Vector3 (zDiff, defaultPosition.y, xDiff);
		}
		else if (otherPortalEntranceRotation == 270)
		{
			var zDiff = portal.position.x + offset.z;
			var xDiff = portal.position.z - offset.x;
			result = new Vector3 (zDiff, defaultPosition.y, xDiff);
		}
		return result;
    }

	//Align PortalCamera rotation with player camera rot with regards to rotation of the OtherPortal's gateway object
	private Quaternion TranslateRotation(Quaternion rotation)
	{
		var res = rotation;

		int otherPortalEntranceRotation = (int) OtherPortal.parent.parent.rotation.eulerAngles.y;
		switch (otherPortalEntranceRotation) 
		{
		case 90:
			res = Quaternion.Euler (res.eulerAngles.x, res.eulerAngles.y + 90 ,res.eulerAngles.z);
				break;
		case 270:
			res = Quaternion.Euler (res.eulerAngles.x, res.eulerAngles.y - 90, res.eulerAngles.z);
			break;
		}
		return res;
	}
}