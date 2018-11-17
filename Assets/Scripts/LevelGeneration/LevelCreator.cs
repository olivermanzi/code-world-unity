using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

    private JSONParser _jsonParser;
    private GameObjectCreator _gameObjectCreator;


	// Use this for initialization
	void Start () {
        _jsonParser = new JSONParser();
        _gameObjectCreator = new GameObjectCreator();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
