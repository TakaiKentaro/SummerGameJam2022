using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        SceneChange((int)SceneType.Intro);
    }

    public void GotoGameScene()
    {
        SceneChange((int)SceneType.Game);
    }

    /// <summary>
    /// ���U���g��ʂ֑J�ڂ���֐�
    /// </summary>
    public void GoToResultScene()
    {
        SceneChange((int)SceneType.Result);
    }

    /// <summary>
    /// �^�C�g����ʂ֑J�ڂ���֐�
    /// </summary>
    public void GoToTitleScene()
    {
        SceneChange((int)SceneType.Title);
    }
}
