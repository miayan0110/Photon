using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �s��Sprite������
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

        DontDestroyOnLoad(this.gameObject); //�b���������ɤ��R���o�Ӫ���
    }

    /// <summary>
    /// �ΨӨ��o�ݭn��Sprite
    /// </summary>
    /// <param name="objName">Sprite�W��</param>
    /// <returns>�ݭn��Sprite</returns>
    public Sprite GetSprite(string objName)
    {
        switch (objName)
        {
            case "���a1":
                return character1;
            case "���a2":
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
