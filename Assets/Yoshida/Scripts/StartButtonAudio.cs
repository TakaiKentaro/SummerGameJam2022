using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �{�^�����������ۂɉ���炷�R���|�[�l���g
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class StartButtonAudio : MonoBehaviour
{
    [Tooltip("�Đ��pAudioSource")] AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PushedStartButton()
    {

        _audioSource.Play();

    }
}
