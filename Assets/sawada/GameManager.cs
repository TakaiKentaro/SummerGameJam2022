using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //時間
    public float _time = 5.0f;
    bool _gameEnd = false;
    [SerializeField] Text _timeText;
    [SerializeField] GameObject _player;
    [SerializeField] Text _scoerText;

    //カーソル
   [SerializeField] bool _mousePointer = true;

    //スコア
    public int _score;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    //プレイヤースポーン
    void Start()
    {

        _player.SetActive(true);
        _mousePointer = false;
        Cursor.visible = false;


    }

    void Update()
    {
        _time -= Time.deltaTime;
        _timeText.text = $"{(int)_time}秒";

        if (_time <= 0)
        {

            _gameEnd = true;
            Cursor.visible = true;
            
        }
    }
    public void AdeScore()
    {
        _score++;
    }
    
}
