using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �{�^�����������ۂɉ���炷�R���|�[�l���g
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
