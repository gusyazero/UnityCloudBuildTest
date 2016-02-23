using UnityEngine;
using System.Collections;

public class HighScoreCountUp : MonoBehaviour {

    public GameData gameData;
    
    public void CountUp()
    {
        gameData.highScore++;
    }
}
