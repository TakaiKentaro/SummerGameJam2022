using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoFinish : MonoBehaviour
{
    [SerializeField] VideoPlayer _player;
    [SerializeField] SceneChangeManager _sceneMan;
    private void Start()
    {
        _player.loopPointReached += LoopPointReached;
        _player.Play();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoopPointReached(_player);
        }
    }
    public void LoopPointReached(VideoPlayer vid)
    {
        _sceneMan.GotoGameScene();
    }
}