using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �ΨӨ��o���~��Sprite(�T�O������)
/// </summary>
public class SpritesGetter : MonoBehaviour
{
    AttributeManager am;
    SpritesContainer sc;

    void Start()
    {
        am = this.gameObject.GetComponent<AttributeManager>();
        sc = GameObject.Find("SpritesContainer").GetComponent<SpritesContainer>();

        if (this.gameObject.tag == "Character")
        {
            this.gameObject.GetComponent<Image>().sprite = sc.GetSprite(CharacSelector.characID);
        }
        
    }

    void Update()
    {
        //�p�G���~�S����Sprite�N�hSpriteContainer��
        if (this.gameObject.GetComponent<Image>().sprite == null && am.GetObjName() != "")
        {
            this.gameObject.GetComponent<Image>().sprite = sc.GetSprite(am.GetObjName());
        }
    }

}
