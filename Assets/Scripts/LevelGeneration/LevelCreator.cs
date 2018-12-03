using System;
using System.IO;
using UnityEngine;

namespace Project{
    public class LevelCreator : MonoBehaviour {

        private JSONParser _jsonParser;
        private GameObjectCreator _gameObjectCreator;
        private StreamReader _streamReader;

        // Use this for initialization
        void Start () {
            _jsonParser = new JSONParser();
            _gameObjectCreator = ScriptableObject.CreateInstance("GameObjectCreator") as GameObjectCreator;

            string path = "Assets/Resources/mock.json"; //TODO: Change this so filename is more dynamic
            _streamReader = new StreamReader(path);
            SetupWorld();
        }

        public void SetupWorld()
        {
            string json = _streamReader.ReadToEnd();
            ClassObject[] classes = _jsonParser.Parse<ClassObject>(json);
            int i = 1;
            foreach (var c in classes)
            {
               Debug.Log("Room: " + i++);
               _gameObjectCreator.Compose(c);
            }

            Debug.Log(_jsonParser.ToJson<ClassObject>(classes)); // DEV only
        }
    }
}