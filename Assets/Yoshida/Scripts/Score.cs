using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアを保存しておく
/// </summary>
public class Score : MonoBehaviour
{
    public static Score Instance;
    public static int _score;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
