using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData
{
    public int highScore = 0;
    public string sceneName = "";
}

/// <summary>
/// ゲームデータ用のクラス
/// </summary>
/// <see cref="http://tsubakit1.hateblo.jp/entry/2015/11/07/024350"/>
public class GameData : MonoBehaviour {

    public static GameData Instance
    {
        get;
        private set;
    }

    private static readonly string SavePath = Application.dataPath + "/save.bytes";
    public int highScore = 0;
    public string sceneName = "";

    void Awake ()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            // Debug.Log("game data destroy!");
            return;
        }
        // Debug.Log("game data create!");

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // iOS用のおまじない
#if UNITY_IPHONE
        Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
#endif

        read();
    }

    // サスペンド・レジュームハンドラ
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Debug.Log("applicationWillResignActive or onPause");
            save();
        } else
        {
            Debug.Log("applicationDidBecomeActive or onResume");
            read();
        }
    }

    // アプリ終了ハンドラ
    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        save();
    }

    void save()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        if (sceneName == null || sceneName == "")
        {
            sceneName = SceneManager.GetActiveScene().name;
        }
        data.sceneName = sceneName;
        using (FileStream fs = new FileStream(SavePath, FileMode.Create, FileAccess.Write))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, data);
        }
    }

    void read()
    {
        using (FileStream fs = new FileStream(SavePath, FileMode.Open, FileAccess.Read))
        {
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                SaveData data = bf.Deserialize(fs) as SaveData;
                highScore = data.highScore;
                sceneName = data.sceneName;
            }
            catch (Exception e)
            {
                // TODO なんかエラーハンドリング
                Debug.LogError(e.StackTrace.ToString());
            }
        }
    }
}
