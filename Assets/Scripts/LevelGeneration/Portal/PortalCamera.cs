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
        playerCamera = GameObject.FindWithTag("Player").transform;
        
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
            Vector3 offset = playerCamera.position - OtherPortal.position;
            transform.position =  portal.position - offset;

            float angularDiffInPortalRotations = Quaternion.Angle(portal.localRotation, OtherPortal.localRotation);

            Quaternion portalRotationDiff = Quaternion.AngleAxis(angularDiffInPortalRotations, Vector3.up);
            Vector3 newCameraDir = (portalRotationDiff * playerCamera.forward);
            transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);
            transform.rotation *= Quaternion.Euler(0,-Quaternion.Angle(OtherPortal.localRotation, OtherPortal.parent.parent.localRotation),0);
    }
}
