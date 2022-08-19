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
    [SerializeField] SceneChangeManager _sceneManager;

    //�J�[�\��
    [SerializeField] bool _mousePointer = true;

    //�X�R�A
    public int _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //�v���C���[�X�|�[��
    void Start()
    {
        _player.SetActive(true);
        //�v���C���[�̃T�C�Y�̒ʒm�����炤
        _player.GetComponent<Player>()._sizeChanger += PlayerSizejudge;
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
            _sceneManager.NextScene();
        }
    }
    public void AdeScore()
    {
        _score++;
    }

    void PlayerSizejudge(int size)
    {
        if (size == 0)
        {
            _sceneManager.NextScene();
        }
    }
}