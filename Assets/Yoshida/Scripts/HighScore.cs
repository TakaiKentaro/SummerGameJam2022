using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ハイスコアを保存しておくコンポーネント
/// </summary>
public class HighScore : MonoBehaviour
{
    public static int _highScore = 5;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
