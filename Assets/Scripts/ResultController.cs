using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultController : MonoBehaviour {

    public Text scoreText;
    private GameData gameData;

    // Use this for initialization
    void Start()
    {
        gameData = GameData.Instance;
        gameData.highScore = 30;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameData.highScore.ToString();

        // 開始処理
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Title");
        }
    }

}
