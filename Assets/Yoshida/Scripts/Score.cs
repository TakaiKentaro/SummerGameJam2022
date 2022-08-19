using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアを保存しておく
/// </summary>
public class Score : MonoBehaviour
{
    public static int _score = 0;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
