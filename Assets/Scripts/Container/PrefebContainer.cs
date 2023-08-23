using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �s��Prefeb������
/// </summary>
public class PrefebContainer : MonoBehaviour
{
    public static PrefebContainer instance;

    [SerializeField] GameObject key;
    [SerializeField] GameObject clock;
    [SerializeField] GameObject notebook;
    [SerializeField] GameObject teaBottle;

    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject); //�b���������ɤ��R���o�Ӫ���
    }

    /// <summary>
    /// �ΨӮ����ݭn��Prefeb
    /// </summary>
    /// <param name="name">Prefeb�W��</param>
    /// <returns>�n���o��Prefeb</returns>
    public GameObject FindGameObj(string name)
    {
        switch (name)
        {
            case "key":
                return key;
            case "clock":
                return clock;
            case "notebook":
                return notebook;
            case "teaBottle":
                return teaBottle;
            default:
                return null;
        }
    }
}
