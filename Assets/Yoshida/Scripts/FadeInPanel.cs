using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// パネルをフェードインさせるコンポーネント
/// </summary>
public class FadeInPanel : MonoBehaviour
{
    [Tooltip("フェードインさせるPanel"), SerializeField] Image _fadeInPanel;
    [Tooltip("アルファ値")] float _alpha = 1f;
    [Tooltip("フェードインのスピード"), SerializeField] float _fadeSpeed = 0.02f;

    bool _isFade = false;

    private void Start()
    {
        StartCoroutine("FadeIn");
    }

    private void Update()
    {
        if (_isFade == true)
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator FadeIn()
    {
        Color c = _fadeInPanel.color;
        c.a = _alpha;
        _fadeInPanel.color = c;
        while (true)
        {
            yield return null;
            c.a -= _fadeSpeed;
            _fadeInPanel.color = c;
            Debug.Log(_fadeInPanel.color.a);

            if (c.a <= 0)
            {
                c.a = 0f;
                _fadeInPanel.color = c;
                _isFade = true;
                break;
            }
        }
    }
}
