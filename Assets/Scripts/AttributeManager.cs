using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    /// <summary>
    /// 物品名稱(ID)
    /// 可以用來取得物品圖片
    /// </summary>
    [SerializeField] string objName = "";

    /// <summary>
    /// 可以通過此物拿到的東西(若有多個物品則依照取得順序排列)
    /// </summary>
    [SerializeField] string[] obj2Get;
    /// <summary>
    /// 決定拿到的東西要顯示在那些玩家的畫面上(物品的接收者)
    /// </summary>
    [SerializeField] RpcTarget[] receiverOfObj2Get;
    /// <summary>
    /// 決定能不能重複觸發(取得)拿到的東西
    /// 1-不能重複觸發(取得)；2-可以重複觸發
    /// </summary>
    [SerializeField] int[] repeatedTimes;

    /// <summary>
    /// 若可以通過此物拿到多個東西則用來紀錄目前取得的物品
    /// </summary>
    [SerializeField] int objGetCounter = 0;
    

    /// <summary>
    /// 設定物品名稱
    /// </summary>
    /// <param name="name"></param>
    public void SetObjName(string name)
    {
        objName = name.Replace("(Clone)", string.Empty);
    }

    /// <summary>
    /// 取得物品名稱(ID)
    /// </summary>
    /// <returns></returns>
     public string GetObjName()
    {
        return objName;
    }

    /// <summary>
    /// 取得該次點擊應該拿到的東西物品的接收者
    /// </summary>
    /// <returns>RpcTarget: 接收者；string: 物品名稱；int: 可重複觸發次數</returns>
    public (RpcTarget, string, int) Get2GetObj()
    {
        //沒東西會透過這個物品取得
        if (obj2Get.Length == 0)
        {
            return (RpcTarget.MasterClient, null, 0);
        }

        //點擊次數超過點擊該物可以獲得的回饋(再次從頭開始)
        if(objGetCounter == obj2Get.Length)
        {
            objGetCounter = 0;
        }

        //目前應該獲得的物品的屬性
        RpcTarget rpc = receiverOfObj2Get[objGetCounter];
        string name = obj2Get[objGetCounter];
        int times = repeatedTimes[objGetCounter];

        //只能獲得一次的物品就將獲得次數設定為0
        if (times == 1)
        {
            repeatedTimes[objGetCounter]--;
        }
        objGetCounter++;    //指到下一個可以獲得的物品

        return (rpc, name, times);
    }

    void Start()
    {
        //同步玩家
        if (this.gameObject.tag == "Character")
        {
            objName = CharacSelector.characID;
        }
    }
}
