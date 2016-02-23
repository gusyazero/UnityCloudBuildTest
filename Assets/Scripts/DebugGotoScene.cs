using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DebugGotoScene : MonoBehaviour {

    public void GotoResult()
    {
        SceneManager.LoadScene("Result");
    }
}
