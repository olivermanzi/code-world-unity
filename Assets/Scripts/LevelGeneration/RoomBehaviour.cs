using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Project
{
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
                UpdateSubRooms ();
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
                UpdateSubRooms ();
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
                UpdateSubRooms ();
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
                UpdateSubRooms ();
            }
        }

        // Use this for initialization
        void Awake()
        {
            subrooms = new List<GameObject>();

            for (var i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).CompareTag("LeftDoorEntry"))
                {
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
            LeftTeleporter.GetComponent<Portal> ().receiver = AssociationsRoomTeleporter;
            RightTeleporter.GetComponent<Portal> ().receiver = ComponentsRoomTeleporter;
            FrontTeleporter.GetComponent<Portal> ().receiver = InheritenceRoomTeleporter;
            BackTeleporter.GetComponent<Portal> ().receiver = PreviousRoomTeleporter;
        }

        public void SetObserverCamera(Transform newCamera)
        {
            foreach (var room in subrooms) {
                room.transform.Find ("PortalCamera").GetComponent<PortalCamera> ().playerCamera = newCamera;
            }
        }

        private void UpdateSubRooms()
        {
            subrooms = new List<GameObject>();
            if(AssociationsRoomTeleporter != null) subrooms.Add (AssociationsRoomTeleporter.parent.parent.parent.gameObject);
            if(ComponentsRoomTeleporter != null) subrooms.Add (ComponentsRoomTeleporter.parent.parent.parent.gameObject);
            if(InheritenceRoomTeleporter != null) subrooms.Add (InheritenceRoomTeleporter.parent.parent.parent.gameObject);
            if(PreviousRoomTeleporter != null) subrooms.Add (PreviousRoomTeleporter.parent.parent.parent.gameObject);
        }
    }
}
