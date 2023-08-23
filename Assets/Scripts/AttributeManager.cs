using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    /// <summary>
    /// ���~�W��(ID)
    /// �i�H�ΨӨ��o���~�Ϥ�
    /// </summary>
    [SerializeField] string objName = "";

    /// <summary>
    /// �i�H�q�L�������쪺�F��(�Y���h�Ӫ��~�h�̷Ө��o���ǱƦC)
    /// </summary>
    [SerializeField] string[] obj2Get;
    /// <summary>
    /// �M�w���쪺�F��n��ܦb���Ǫ��a���e���W(���~��������)
    /// </summary>
    [SerializeField] RpcTarget[] receiverOfObj2Get;
    /// <summary>
    /// �M�w�ण�୫��Ĳ�o(���o)���쪺�F��
    /// 1-���୫��Ĳ�o(���o)�F2-�i�H����Ĳ�o
    /// </summary>
    [SerializeField] int[] repeatedTimes;

    /// <summary>
    /// �Y�i�H�q�L��������h�ӪF��h�ΨӬ����ثe���o�����~
    /// </summary>
    [SerializeField] int objGetCounter = 0;
    

    /// <summary>
    /// �]�w���~�W��
    /// </summary>
    /// <param name="name"></param>
    public void SetObjName(string name)
    {
        objName = name.Replace("(Clone)", string.Empty);
    }

    /// <summary>
    /// ���o���~�W��(ID)
    /// </summary>
    /// <returns></returns>
     public string GetObjName()
    {
        return objName;
    }

    /// <summary>
    /// ���o�Ӧ��I�����Ӯ��쪺�F�誫�~��������
    /// </summary>
    /// <returns>RpcTarget: �����̡Fstring: ���~�W�١Fint: �i����Ĳ�o����</returns>
    public (RpcTarget, string, int) Get2GetObj()
    {
        //�S�F��|�z�L�o�Ӫ��~���o
        if (obj2Get.Length == 0)
        {
            return (RpcTarget.MasterClient, null, 0);
        }

        //�I�����ƶW�L�I���Ӫ��i�H��o���^�X(�A���q�Y�}�l)
        if(objGetCounter == obj2Get.Length)
        {
            objGetCounter = 0;
        }

        //�ثe������o�����~���ݩ�
        RpcTarget rpc = receiverOfObj2Get[objGetCounter];
        string name = obj2Get[objGetCounter];
        int times = repeatedTimes[objGetCounter];

        //�u����o�@�������~�N�N��o���Ƴ]�w��0
        if (times == 1)
        {
            repeatedTimes[objGetCounter]--;
        }
        objGetCounter++;    //����U�@�ӥi�H��o�����~

        return (rpc, name, times);
    }

    void Start()
    {
        //�P�B���a
        if (this.gameObject.tag == "Character")
        {
            objName = CharacSelector.characID;
        }
    }
}
