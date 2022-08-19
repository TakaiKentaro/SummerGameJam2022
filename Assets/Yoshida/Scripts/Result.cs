using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���U���g�V�[���ŃX�R�A��\������R���|�[�l���g
/// </summary>
public class Result : MonoBehaviour
{
    [Tooltip("�n�C�X�R�A��"), SerializeField] Canvas _highScoreImage;
    [Tooltip("�ʏ�"), SerializeField] Canvas _nomalScoreImage;

    [Tooltip("�X�R�A�̃e�L�X�g"), SerializeField] Text _scoreText;

    int _score;
    int _highScore = 0;

    private void Start()
    {
        _score = Score._score;
        _highScore = HighScore._highScore;

        if (_score > _highScore)
        {
            Debug.Log("�n�C�X�R�A");
            _nomalScoreImage.gameObject.SetActive(false);
            _highScoreImage.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("�ʏ�");
            _highScoreImage.gameObject.SetActive(false);
            _nomalScoreImage.gameObject.SetActive(true);
        }

        _scoreText.text = _score.ToString();
    }
}
