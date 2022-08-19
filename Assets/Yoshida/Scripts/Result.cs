using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// リザルトシーンでスコアを表示するコンポーネント
/// </summary>
public class Result : MonoBehaviour
{
    [Tooltip("ハイスコア時"), SerializeField] Canvas _highScoreImage;
    [Tooltip("通常"), SerializeField] Canvas _nomalScoreImage;

    [Tooltip("スコアのテキスト"), SerializeField] Text _scoreText;

    int _score;
    int _highScore = 0;

    private void Start()
    {
        _score = Score._score;
        _highScore = HighScore._highScore;

        if (_score > _highScore)
        {
            Debug.Log("ハイスコア");
            _nomalScoreImage.gameObject.SetActive(false);
            _highScoreImage.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("通常");
            _highScoreImage.gameObject.SetActive(false);
            _nomalScoreImage.gameObject.SetActive(true);
        }

        _scoreText.text = _score.ToString();
    }
}
