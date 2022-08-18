using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //����
    public float _time = 5.0f;
    bool _gameEnd = false;
    [SerializeField] Text _timeText;
    [SerializeField] GameObject _player;
    [SerializeField] Text _scoerText;

    //�J�[�\��
   [SerializeField] bool _mousePointer = true;

    //�X�R�A
    public int _score;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    //�v���C���[�X�|�[��
    void Start()
    {

        _player.SetActive(true);
        _mousePointer = false;
        Cursor.visible = false;


    }

    void Update()
    {
        _time -= Time.deltaTime;
        _timeText.text = $"{(int)_time}�b";

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
