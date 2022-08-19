
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//�I�u�W�F�N�g��NavMeshAgent�R���|�[�l���g��ݒu
[RequireComponent(typeof(NavMeshAgent))]

public class EnemyRandomMove : MonoBehaviour
{
    //�ʒu�̊�ɂȂ�I�u�W�F�N�g��Transform�����߂�
    public Transform central;

    private NavMeshAgent agent;
    //�����_���Ō��߂鐔�l�̍ő�l
    [SerializeField] float radius = 3;
    //�ݒ肵���ҋ@����
    [SerializeField] float waitTime = 2;
    //�ҋ@���Ԃ𐔂���
    [SerializeField] float time = 0;

    Animator anim;

    //Vector3 pos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //�ڕW�n�_�ɋ߂Â��Ă����x�𗎂Ƃ��Ȃ��Ȃ�
        agent.autoBraking = false;
        //�ڕW�n�_�����߂�
        GotoNextPoint();
    }
    void GotoNextPoint()
    {
        //NavMeshAgent�̃X�g�b�v������
        agent.isStopped = false;

        //�ڕW�n�_��X���AZ���������_���Ō��߂�
        float posX = Random.Range(-1 * radius, radius);
        float posZ = Random.Range(-1 * radius, radius);

        //CentralPoint�̈ʒu��PosX��PosZ�𑫂�
        Vector3 pos = central.position;
        pos.x += posX;
        pos.z += posZ;

        //NavMeshAgent�ɖڕW�n�_��ݒ肷��
        agent.destination = pos;
    }

    void StopHere()
    {
        //NavMeshAgent���~�߂�
        agent.isStopped = true;
        //�҂����Ԃ𐔂���
        time += Time.deltaTime;

        //�҂����Ԃ��ݒ肳�ꂽ���l�𒴂���Ɣ���
        if (time > waitTime)
        {
            //�ڕW�n�_��ݒ肵����
            GotoNextPoint();
            time = 0;
        }
    }

    void Update()
    {
        //�o�H�T���̏������ł��Ă��炸
        //�ڕW�n�_�܂ł̋�����0.5m�����Ȃ�NavMeshAgent���~�߂�
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            StopHere();
    }
}