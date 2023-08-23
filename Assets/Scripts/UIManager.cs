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

        //如果沒有要透過剛才點擊的物品拿到東西
        if (obj2Get.Item2 == null)
        {
            return;
        }
        else if (obj2Get.Item3 < 1)
        {
            //顯示文字之類的
            param.text = obj2Get.Item2 + "已經被我拿走了"; //例
            return;
        }

        if(obj2Get.Item1 != RpcTarget.MasterClient)
        {
            //如果要傳送給其他人
            photonView.RPC("CreatePrefebsInToolbox", obj2Get.Item1, obj2Get.Item2);
        }
        else
        {
            //只在自己的畫面生成
            CreatePrefebsInToolbox(obj2Get.Item2);
        }

    }

    /// <summary>
    /// 在道具欄生成Prefeb
    /// </summary>
    /// <param name="objname">要生成的Prefeb名稱</param>
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
    /// 找空的工具欄
    /// </summary>
    /// <returns>空的工具欄；沒有空的工具欄則回傳null</returns>
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
