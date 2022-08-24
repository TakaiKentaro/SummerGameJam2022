using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �n�C�X�R�A��ۑ����Ă����R���|�[�l���g
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
