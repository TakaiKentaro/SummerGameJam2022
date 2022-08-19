using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボタンを押した際に音を鳴らすコンポーネント
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class StartButtonSound : MonoBehaviour
{
    [Tooltip("AudioSource")] AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlayStartSound()
    {
        _audio.Play();
    }
}
