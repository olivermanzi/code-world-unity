using System;
using System.IO;
using UnityEngine;

namespace Project{
    public class LevelCreator : MonoBehaviour {

        private JSONParser _jsonParser;
        private GameObjectCreator _gameObjectCreator;
        private StreamReader _streamReader;
        private Backtracker _backtracker;

        // Use this for initialization
        void Start () {
            _jsonParser = new JSONParser();
            _gameObjectCreator = ScriptableObject.CreateInstance("GameObjectCreator") as GameObjectCreator;
            _backtracker = GameObject.Find("Backtracker").GetComponent<Backtracker>();

            string path = "Assets/Resources/mock.json"; //TODO: Change this so filename is more dynamic
            _streamReader = new StreamReader(path);
            SetupWorld();
        }

        public void SetupWorld()
        {
            ClassObject[] classes = GetClassObjects();
            _gameObjectCreator.Compose(classes);
            GameObject.Find("PortalCameraManager").GetComponent<PortalCameraManager>().CycleCameras();
            _backtracker.EnterRoom();
        }

        public ClassObject[] GetClassObjects()
        {
            string json = _streamReader.ReadToEnd();
            ClassObject[] classes = _jsonParser.Parse<ClassObject>(json);
            return classes;
        }
    }
}