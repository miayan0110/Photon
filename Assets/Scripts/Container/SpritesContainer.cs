using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存放Sprite的物件
/// </summary>
public class SpritesContainer : MonoBehaviour
{
    public static SpritesContainer instance;

    [SerializeField] Sprite character1;
    [SerializeField] Sprite character2;
    [SerializeField] Sprite key;
    [SerializeField] Sprite clock;
    [SerializeField] Sprite notebook;
    [SerializeField] Sprite teaBottle;

    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject); //在切換場景時不刪除這個物件
    }

    /// <summary>
    /// 用來取得需要的Sprite
    /// </summary>
    /// <param name="objName">Sprite名稱</param>
    /// <returns>需要的Sprite</returns>
    public Sprite GetSprite(string objName)
    {
        switch (objName)
        {
            case "玩家1":
                return character1;
            case "玩家2":
                return character2;
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
