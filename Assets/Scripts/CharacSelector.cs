using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacSelector : MonoBehaviourPunCallbacks
{
    public static string characID;

    [SerializeField] Button charac1;
    [SerializeField] Button charac2;

    RoomOptions roomOptions = new RoomOptions() { MaxPlayers = 2 };
    int roomCount;

    MusicPlayer bgmPlayer, sePlayer;

    public void OnCharac1BtnClick()
    {
        // 撥放音效
        sePlayer.Play("Press");

        characID = "玩家1";
        photonView.RPC("DisableButton", RpcTarget.AllBuffered, "charac1");
        SceneManager.LoadScene("ChatScene");

        //StartCoroutine(Wait2ChangeScene());
    }

    public void OnCharac2BtnClick()
    {
        // 撥放音效
        sePlayer.Play("Press");

        characID = "玩家2";
        photonView.RPC("DisableButton", RpcTarget.AllBuffered, "charac2");
        SceneManager.LoadScene("ChatScene");

        //StartCoroutine(Wait2ChangeScene());
    }

    /// <summary>
    /// 關掉按鈕
    /// </summary>
    /// <param name="characPressed"></param>
    [PunRPC]
    void DisableButton(string characPressed)
    {
        charac1.interactable = characPressed == "charac1" ? false : true;
        charac2.interactable = characPressed == "charac2" ? false : true;
    }

    /// <summary>
    /// wait
    /// </summary>
    /// <returns></returns>
    IEnumerator Wait2ChangeScene()
    {
        yield return new WaitForSeconds(sePlayer.MusicLength() - 1);
        SceneManager.LoadScene("ChatScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        roomCount = 0;
        charac1.interactable = false;
        charac2.interactable = false;
        PhotonNetwork.ConnectUsingSettings();

        bgmPlayer = GameObject.Find("BGMPlayer").GetComponent<MusicPlayer>();
        sePlayer = GameObject.Find("SoundEffectPlayer").GetComponent<MusicPlayer>();
        bgmPlayer.Play("Bgm1", true);
    }


    #region CallBacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master!");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby.");
        PhotonNetwork.JoinOrCreateRoom("DefaultRoom"+roomCount.ToString(), roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room.");
        charac1.interactable = true;
        charac2.interactable = true;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log(returnCode + " " + message);
        roomCount++;
        PhotonNetwork.JoinOrCreateRoom("DefaultRoom" + roomCount.ToString(), roomOptions, TypedLobby.Default);
    }

    #endregion
}
