using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RoomBehaviour : MonoBehaviour
{
    public List<GameObject> subrooms;
    private Transform _componentsRoomTeleporter;
    private Transform _associationsRoomTeleporter;
    private Transform _inheritenceRoomTeleporter;
    private Transform _previousRoomTeleporter;
    private Transform _leftTeleporter;
    private Transform _rightTeleporter;
    private Transform _frontTeleporter;
    private Transform _backTeleporter;

    public Transform LeftTeleporter
    {
        get
        {
            return _leftTeleporter;
        }
        set
        {
            _leftTeleporter = value;
        }
    }
    public Transform RightTeleporter
    {
        get
        {
            return _rightTeleporter;
        }
        set
        {
            _rightTeleporter = value;
        }
    }
    public Transform FrontTeleporter
    {
        get
        {
            return _frontTeleporter;
        }
        set
        {
            _frontTeleporter = value;
        }
    } //The entrance in front of the player when they enter
    public Transform BackTeleporter
    {
        get
        {
            return _backTeleporter;
        }
        set
        {
            _backTeleporter = value;
        }
    } //The entrance the player to the room arrives through

    public Transform ComponentsRoomTeleporter
    {
        get
        {
            return _componentsRoomTeleporter;
        }
        set
        {
            _componentsRoomTeleporter = value;
            if (RightTeleporter != null)
            {
                RightTeleporter.GetComponent<Portal>().receiver = value;
            }
        }
    }
    public Transform AssociationsRoomTeleporter
    {
        get
        {
            return _associationsRoomTeleporter;
        }
        set
        {
            _associationsRoomTeleporter = value;
            if (LeftTeleporter != null)
            {
                LeftTeleporter.GetComponent<Portal>().receiver = value;
            }
        }
    }
    public Transform InheritenceRoomTeleporter
    {
        get
        {
            return _inheritenceRoomTeleporter;
        }
        set
        {
            _inheritenceRoomTeleporter = value;
            if (FrontTeleporter != null)
            {
                FrontTeleporter.GetComponent<Portal>().receiver = value;
            }
        }
    }
    public Transform PreviousRoomTeleporter
    {
        get
        {
            return _previousRoomTeleporter;
        }
        set
        {
            _previousRoomTeleporter = value;
            if (BackTeleporter != null)
            {
                BackTeleporter.Find("PortalTeleporter").GetComponent<Portal>().receiver = value;
            }
        }
    }

    // Use this for initialization
    void Awake()
    {
        subrooms = new List<GameObject>(); // UH WHATEVER THAT IS FOR

        for (var i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("LeftDoorEntry"))
            {
                Debug.Log("yoot");
                LeftTeleporter = transform.GetChild(i).transform.Find("Doorway/PortalTeleporter");
            }
            if (transform.GetChild(i).CompareTag("RightDoorEntry"))
            {
                RightTeleporter = transform.GetChild(i).transform.Find("Doorway/PortalTeleporter");
            }
            if (transform.GetChild(i).CompareTag("BackDoorEntry"))
            {
                BackTeleporter = transform.GetChild(i).transform.Find("Doorway/PortalTeleporter");
            }
            if (transform.GetChild(i).CompareTag("FrontDoorEntry"))
            {
                FrontTeleporter = transform.GetChild(i).transform.Find("Doorway/PortalTeleporter");
            }
        }
    }

    void Start(){
        SetupTeleports();
    }

    public void SetupTeleports()
    {
        LeftTeleporter.GetComponent<Portal>().receiver = AssociationsRoomTeleporter;
        RightTeleporter.GetComponent<Portal>().receiver = ComponentsRoomTeleporter;
        FrontTeleporter.GetComponent<Portal>().receiver = InheritenceRoomTeleporter;
        BackTeleporter.GetComponent<Portal>().receiver = PreviousRoomTeleporter;
    }
}
