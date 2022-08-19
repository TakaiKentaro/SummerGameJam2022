using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボタンを押した際に音を鳴らすコンポーネント
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class StartButtonAudio : MonoBehaviour
{
    [Tooltip("再生用AudioSource")] AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PushedStartButton()
    {

        _audioSource.Play();

    }
}
