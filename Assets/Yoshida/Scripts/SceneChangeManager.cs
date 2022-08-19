using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

/// <summary>
/// �Q�[���S�̂̃V�[�����Ǘ�����R���|�[�l���g
/// </summary>
public class SceneChangeManager : MonoBehaviour
{
    public enum SceneType
    {
        Title = 0,
        Intro = 1,
        Game = 2,
        Result = 3,
    }

    [Header("���o�p")]
    [Tooltip("�t�F�[�h�A�E�g�pPanel"), SerializeField] Image _fadeOutPanel;
    [Tooltip("�t�F�[�h�A�E�g�̃X�s�[�h"), SerializeField] float _fadeSpeed = 0.002f;
    [Tooltip("Panel�̃A���t�@�l")] float _alpha = 0.0f;

    [Tooltip("���݂̃V�[��")] Scene _currentScene;
    [Tooltip("�V�[���̐�")] int _sceneCount = 0;

    private void Start()
    {
        _sceneCount = SceneManager.sceneCountInBuildSettings;
        Debug.Log(_sceneCount);

        _currentScene = SceneManager.GetActiveScene();
    }

    /// <summary>
    /// �V�[���J�ڂɎg���֐�
    /// </summary>
    /// <param name="sceneIndex">�J�ڂ���V�[���ԍ�</param>
    void SceneChange(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        _currentScene = SceneManager.GetActiveScene();
    }

    /// <summary>
    /// �w�肵���V�[���ɑJ�ڂ���֐�
    /// </summary>
    /// <param name="sceneIndex">�J�ڂ���V�[���ԍ�</param>
    public void LoadAssignedScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// ���̃V�[���֑J�ڂ���֐�
    /// </summary>
    public void NextScene()
    {
        SceneChange(_currentScene.buildIndex + 1);
    }

    /// <summary>
    /// ���̃V�[����������x���[�h����֐�
    /// </summary>
    public void PlayCurrentSceneAgain()
    {
        SceneChange(_currentScene.buildIndex);
    }

    /// <summary>
    /// �C���g���V�[���֑J�ڂ���֐�
    /// </summary>
    public void GoToIntroScene()
    {
        StartCoroutine("FadeOutToIntro");
    }

    /// <summary>
    /// �Q�[���V�[���֑J�ڂ���֐�
    /// </summary>
    public void GotoGameScene()
    {
        StartCoroutine("FadeOutToGame");
    }

    /// <summary>
    /// ���U���g��ʂ֑J�ڂ���֐�
    /// </summary>
    public void GoToResultScene()
    {
        StartCoroutine("FadeOutToResult");
    }

    /// <summary>
    /// �^�C�g����ʂ֑J�ڂ���֐�
    /// </summary>
    public void GoToTitleScene()
    {
        StartCoroutine("FadeOutToTitle");
    }

    /// <summary>
    /// �f���V�[���p�t�F�[�h�A�E�g
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOutToIntro()
    {
        Color c = _fadeOutPanel.color;
        c.a = _alpha;
        _fadeOutPanel.color = c;
        while (true)
        {
            yield return null;
            c.a += _fadeSpeed;
            _fadeOutPanel.color = c;

            if (c.a >= 1)
            {
                c.a = 1f;
                _fadeOutPanel.color = c;
                SceneChange((int)SceneType.Intro);
                break;
            }
        }
    }

    /// <summary>
    /// �Q�[���V�[���p�t�F�[�h�A�E�g
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOutToGame()
    {
        Color c = _fadeOutPanel.color;
        c.a = _alpha;
        _fadeOutPanel.color = c;
        while (true)
        {
            yield return null;
            c.a += _fadeSpeed;
            _fadeOutPanel.color = c;

            if (c.a >= 1)
            {
                c.a = 1f;
                _fadeOutPanel.color = c;
                SceneChange((int)SceneType.Game);
                break;
            }
        }
    }

    /// <summary>
    /// ���U���g�p�t�F�[�h�A�E�g
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOutToResult()
    {
        Color c = _fadeOutPanel.color;
        c.a = _alpha;
        _fadeOutPanel.color = c;
        while (true)
        {
            yield return null;
            c.a += _fadeSpeed;
            _fadeOutPanel.color = c;

            if (c.a >= 1)
            {
                c.a = 1f;
                _fadeOutPanel.color = c;
                SceneChange((int)SceneType.Result);
                break;
            }
        }
    }

    /// <summary>
    /// �^�C�g���p�t�F�[�h�A�E�g
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOutToTitle()
    {
        Color c = _fadeOutPanel.color;
        c.a = _alpha;
        _fadeOutPanel.color = c;
        while (true)
        {
            yield return null;
            c.a += _fadeSpeed;
            _fadeOutPanel.color = c;

            if (c.a >= 1)
            {
                c.a = 1f;
                _fadeOutPanel.color = c;
                SceneChange((int)SceneType.Title);
                break;
            }
        }
    }
}
