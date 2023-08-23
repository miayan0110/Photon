using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 用來取得物品的Sprite(確保有拿到)
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
        //如果物品沒拿到Sprite就去SpriteContainer拿
        if (this.gameObject.GetComponent<Image>().sprite == null && am.GetObjName() != "")
        {
            this.gameObject.GetComponent<Image>().sprite = sc.GetSprite(am.GetObjName());
        }
    }

}
