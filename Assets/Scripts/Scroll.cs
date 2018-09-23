using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    float scrollSpeed;
    float speedFactor;

    GameManager manager;

	// Use this for initialization
	void Start () {

        manager = Camera.main.GetComponent<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {


        this.transform.position -= new Vector3(manager.getScrollSpeed()*Time.deltaTime,0,0);
	}

    
}
