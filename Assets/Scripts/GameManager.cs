using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    float scrollSpeed;
    public CharacterController currentCharacter;
    int score;

	void Start () {
        scrollSpeed = 5.0f;
	}
	
	void Update () {

        scrollSpeed += 0.5f * Time.deltaTime;

        score = (int)Time.time * 100;

        if (currentCharacter.isDead())
        {
            PlayerScore.setHighScore(score);
            SceneManager.LoadScene(1);
        }

	}

    public float getScrollSpeed()
    {
        return scrollSpeed;
    }


}
