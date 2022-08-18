using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour���p������Singleton�������������Ƃ��Ɍp������
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>�V���O���g���N���X�̃C���X�^���X</summary>
    private static T instance;

    /// <summary>�V���O���g���N���X�̃C���X�^���X</summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    Debug.LogError(typeof(T) + "is nothing");
                }
            }
            return instance;
        }
    }

    protected void Awake()
    {
        CheckInstance();
    }

    /// <summary>���̃C���X�^���X��Singleton�����ꂽ�C���X�^���X���ۂ���Ԃ�
    /// �����ۂȂ炱�̃C���X�^���X��j������</summary>
    /// <returns>true �V���O���g�������ꂽ�C���X�^���X : false ��ڈȍ~�̃C���X�^���X</returns>
    protected bool CheckInstance()
    {
        if (this == Instance)
        {
            return true;
        }
        Destroy(this);
        return false;
    }
}
