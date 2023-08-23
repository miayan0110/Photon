using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolBarManager : MonoBehaviour
{
    [SerializeField] GameObject showToolPanel;
    [SerializeField] Image tool2Show;

    public void OnToolBoxClick()
    {
        GameObject selectedBox = EventSystem.current.currentSelectedGameObject;
        string name = selectedBox.transform.GetChild(0).name;

        //設定要顯示的物品，AttributeManager會自己去拿圖片
        if (name!=null || name != "")
        {
            tool2Show.GetComponent<AttributeManager>().SetObjName(name);
            showToolPanel.SetActive(true);  //有需要顯示的物品才顯示
        }

    }

    public void OnShowToolPanelClick()
    {
        tool2Show.GetComponent<AttributeManager>().SetObjName("");
        showToolPanel.SetActive(false);
    }

    void Start()
    {
        showToolPanel.SetActive(false);
    }

}
