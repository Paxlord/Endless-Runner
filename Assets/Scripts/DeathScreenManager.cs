using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        text.text = "Vous êtes mort ! Votre score : " + PlayerScore.getHighScore();

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }

	}
}
