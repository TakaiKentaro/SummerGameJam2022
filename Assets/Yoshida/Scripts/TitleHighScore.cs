using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �^�C�g����ʂɃn�C�X�R�A��\������R���|�[�l���g
/// </summary>
public class TitleHighScore : MonoBehaviour
{
    [Tooltip("�\������n�C�X�R�A�̃e�L�X�g"), SerializeField] Text _highScoreText;


    private void Start()
    {
        _highScoreText.text = HighScore._highScore.ToString();
    }
}
