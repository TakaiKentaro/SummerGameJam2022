using UnityEngine;
using System.Collections;

public class InstantiateTest : MonoBehaviour
{

    //��������Q�[���I�u�W�F�N�g
    public GameObject target;

    void Update()
    {
        //�X�y�[�X����������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate( ��������I�u�W�F�N�g,  �ꏊ, ��] );  ��]�͂��̂܂܂Ȃ火
            Instantiate(target, new Vector3(1.0f, 2.0f, 0.0f), Quaternion.identity);
        }
    }
}