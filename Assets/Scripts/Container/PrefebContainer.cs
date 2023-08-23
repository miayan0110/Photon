using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存放Prefeb的物件
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

        DontDestroyOnLoad(this.gameObject); //在切換場景時不刪除這個物件
    }

    /// <summary>
    /// 用來拿取需要的Prefeb
    /// </summary>
    /// <param name="name">Prefeb名稱</param>
    /// <returns>要取得的Prefeb</returns>
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
