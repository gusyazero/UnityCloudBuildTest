using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleController : MonoBehaviour {

    public Text scoreText;
    private GameData gameData;
    
    // Use this for initialization
	void Start () {
        gameData = GameData.Instance;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameData == null)
        {
            gameData = GameData.Instance;
        }
        scoreText.text = gameData.highScore.ToString();

        // 開始処理
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
//            SceneManager.LoadScene("Result");
        }
	}

}
