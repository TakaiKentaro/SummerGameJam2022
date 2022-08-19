using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイトル画面にハイスコアを表示するコンポーネント
/// </summary>
public class TitleHighScore : MonoBehaviour
{
    [Tooltip("表示するハイスコアのテキスト"), SerializeField] Text _highScoreText;


    private void Start()
    {
        _highScoreText.text = HighScore._highScore.ToString();
    }
}
