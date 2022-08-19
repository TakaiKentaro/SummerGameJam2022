using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeCreator : MonoBehaviour
{
    private static bool IsLoaded { get; set; }

    [Tooltip("SceneChangeManagerのプレハブ"), SerializeField] GameObject _sceneChangeManagerPrefab = null;

    void Awake()
    {
        //すでにロード済みなら、二重に作成しない
        if (IsLoaded) return;

        IsLoaded = true;

        //プレハブをインスタンス化して、DontDestroyOnLoad


        GameObject go = Instantiate(_sceneChangeManagerPrefab);
        DontDestroyOnLoad(go);

    }
}
