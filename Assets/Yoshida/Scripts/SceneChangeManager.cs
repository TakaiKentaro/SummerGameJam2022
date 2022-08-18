using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

/// <summary>
/// ゲーム全体のシーンを管理するコンポーネント
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

    [Tooltip("現在のシーン")] Scene _currentScene;

    [Tooltip("シーンの数")] int _sceneCount = 0;

    private void Start()
    {
        _sceneCount = SceneManager.sceneCountInBuildSettings;
        Debug.Log(_sceneCount);

        _currentScene = SceneManager.GetActiveScene();
    }

    /// <summary>
    /// シーン遷移に使う関数
    /// </summary>
    /// <param name="sceneIndex">遷移するシーン番号</param>
    void SceneChange(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        _currentScene = SceneManager.GetActiveScene();
    }

    /// <summary>
    /// 指定したシーンに遷移する関数
    /// </summary>
    /// <param name="sceneIndex">遷移するシーン番号</param>
    public void LoadAssignedScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// 次のシーンへ遷移する関数
    /// </summary>
    public void NextScene()
    {
        SceneChange(_currentScene.buildIndex + 1);
    }

    /// <summary>
    /// 今のシーンをもう一度ロードする関数
    /// </summary>
    public void PlayCurrentSceneAgain()
    {
        SceneChange(_currentScene.buildIndex);
    }

    /// <summary>
    /// イントロシーンへ遷移する関数
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
    /// リザルト画面へ遷移する関数
    /// </summary>
    public void GoToResultScene()
    {
        SceneChange((int)SceneType.Result);
    }

    /// <summary>
    /// タイトル画面へ遷移する関数
    /// </summary>
    public void GoToTitleScene()
    {
        SceneChange((int)SceneType.Title);
    }
}
