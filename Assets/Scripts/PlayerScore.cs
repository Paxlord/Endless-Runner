using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerScore {


    private static int highScore;

    public static float getHighScore()
    {
        return highScore;
    }

    public static void setHighScore(int score)
    {
        highScore = score;
    }

	
}
