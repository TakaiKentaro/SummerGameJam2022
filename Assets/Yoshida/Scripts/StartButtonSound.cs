using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �{�^�����������ۂɉ���炷�R���|�[�l���g
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
