using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボタンを押した際に音を鳴らすコンポーネント
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class StartButtonSound : MonoBehaviour
{
    [Tooltip("AudioSource"), SerializeField] AudioSource _audio;
    [SerializeField] AudioClip _audioClip;

    private void Start()
    {
        
    }

    public void PlayStartSound()
    {
        _audio.PlayOneShot(_audioClip);
    }
}
