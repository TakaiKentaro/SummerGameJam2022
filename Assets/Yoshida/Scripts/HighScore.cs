using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ハイスコアを保存しておくコンポーネント
/// </summary>
public class HighScore : MonoBehaviour
{
    public static HighScore instance;
    public static int _highScore;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
