using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviourPun
{
    [SerializeField] TMP_Text param;
    [SerializeField] Button[] toolboxes;

    PrefebContainer pc;

    public void OnItemClick()
    {
        GameObject selectedObj = EventSystem.current.currentSelectedGameObject;
        var obj2Get = selectedObj.GetComponent<AttributeManager>().Get2GetObj();

        //�p�G�S���n�z�L��~�I�������~����F��
        if (obj2Get.Item2 == null)
        {
            return;
        }
        else if (obj2Get.Item3 < 1)
        {
            //��ܤ�r������
            param.text = obj2Get.Item2 + "�w�g�Q�ڮ����F"; //��
            return;
        }

        if(obj2Get.Item1 != RpcTarget.MasterClient)
        {
            //�p�G�n�ǰe����L�H
            photonView.RPC("CreatePrefebsInToolbox", obj2Get.Item1, obj2Get.Item2);
        }
        else
        {
            //�u�b�ۤv���e���ͦ�
            CreatePrefebsInToolbox(obj2Get.Item2);
        }

    }

    /// <summary>
    /// �b�D����ͦ�Prefeb
    /// </summary>
    /// <param name="objname">�n�ͦ���Prefeb�W��</param>
    [PunRPC]
    void CreatePrefebsInToolbox(string objname)
    {
        var box = FindEmptyBox();
        param.text = "Get " + objname;

        if (box != null)
        {
            Instantiate(pc.FindGameObj(objname), box.transform, false);
        }
        
    }

    /// <summary>
    /// ��Ū��u����
    /// </summary>
    /// <returns>�Ū��u����F�S���Ū��u����h�^��null</returns>
    Button FindEmptyBox()
    {
        foreach (Button box in toolboxes)
        {
            if (box.transform.childCount == 0) return box;
        }
        return null;
    }

    void Start()
    {
        pc = GameObject.Find("PrefebContainer").GetComponent<PrefebContainer>();
    }

}
