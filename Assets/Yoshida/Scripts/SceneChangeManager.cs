using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [Header("演出用")]
    [Tooltip("フェードアウト用Panel"), SerializeField] Image _fadeOutPanel;
    [Tooltip("フェードアウトのスピード"), SerializeField] float _fadeSpeed = 0.002f;
    [Tooltip("Panelのアルファ値")] float _alpha = 0.0f;

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
        StartCoroutine("FadeOutToIntro");
    }

    /// <summary>
    /// ゲームシーンへ遷移する関数
    /// </summary>
    public void GotoGameScene()
    {
        StartCoroutine("FadeOutToGame");
    }

    /// <summary>
    /// リザルト画面へ遷移する関数
    /// </summary>
    public void GoToResultScene()
    {
        StartCoroutine("FadeOutToResult");
    }

    /// <summary>
    /// タイトル画面へ遷移する関数
    /// </summary>
    public void GoToTitleScene()
    {
        StartCoroutine("FadeOutToTitle");
    }

    /// <summary>
    /// デモシーン用フェードアウト
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
    /// ゲームシーン用フェードアウト
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
    /// リザルト用フェードアウト
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
    /// タイトル用フェードアウト
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
