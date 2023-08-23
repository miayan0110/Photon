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

        //�]�w�n��ܪ����~�AAttributeManager�|�ۤv�h���Ϥ�
        if (name!=null || name != "")
        {
            tool2Show.GetComponent<AttributeManager>().SetObjName(name);
            showToolPanel.SetActive(true);  //���ݭn��ܪ����~�~���
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
