using UnityEngine;
using System.Collections;

public class HighScoreCountUp : MonoBehaviour {

    public GameData gameData;

    void Start()
    {
        gameData = GameData.Instance;
    }

    public void CountUp()
    {
        gameData.highScore++;
    }
}
