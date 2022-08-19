using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeCreator : MonoBehaviour
{
    private static bool IsLoaded { get; set; }

    [Tooltip("SceneChangeManager�̃v���n�u"), SerializeField] GameObject _sceneChangeManagerPrefab = null;

    void Awake()
    {
        //���łɃ��[�h�ς݂Ȃ�A��d�ɍ쐬���Ȃ�
        if (IsLoaded) return;

        IsLoaded = true;

        //�v���n�u���C���X�^���X�����āADontDestroyOnLoad


        GameObject go = Instantiate(_sceneChangeManagerPrefab);
        DontDestroyOnLoad(go);

    }
}
