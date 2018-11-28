using UnityEngine;

public class PortalCamera : MonoBehaviour
{

    public Transform playerCamera;
    public Transform portal;
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
                Debug.Log("Shiieet");

            }
            else
            {
                Debug.Log("omegalol");

            }
        }
    }
    private Material mat;
    private Transform _otherPortal;

    private void Awake()
    {
        var shader = Shader.Find("Unlit/ScreenCutoutShader");

        Camera cam = gameObject.GetComponent<Camera>();
        if (cam.targetTexture != null)
        {
            cam.targetTexture.Release();
        }
        cam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mat = new Material(shader);
        mat.mainTexture = cam.targetTexture;

        playerCamera = GameObject.FindWithTag("Player").transform;
        
    }

    private void Start()
    {
            _otherPortal.GetComponent<MeshRenderer>().material = mat;
    }

    // Update is called once per frame
    void Update()
    {
       
            Vector3 offset = playerCamera.position - OtherPortal.position;
            transform.position = portal.position - offset;

            float angularDiffInPortalRotations = Quaternion.Angle(portal.rotation, OtherPortal.rotation);

            Quaternion portalRotationDiff = Quaternion.AngleAxis(angularDiffInPortalRotations, Vector3.up);
            Vector3 newCameraDir = portalRotationDiff * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);
    }
}
