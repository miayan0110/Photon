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

    public void OnCharac1BtnClick()
    {
        characID = "���a1";
        photonView.RPC("DisableButton", RpcTarget.AllBuffered, "charac1");
        SceneManager.LoadScene("ChatScene");
    }

    public void OnCharac2BtnClick()
    {
        characID = "���a2";
        photonView.RPC("DisableButton", RpcTarget.AllBuffered, "charac2");
        SceneManager.LoadScene("ChatScene");
    }

    [PunRPC]
    void DisableButton(string characPressed)
    {
        charac1.interactable = characPressed == "charac1" ? false : true;
        charac2.interactable = characPressed == "charac2" ? false : true;
    }

    // Start is called before the first frame update
    void Start()
    {
        roomCount = 0;
        charac1.interactable = false;
        charac2.interactable = false;
        PhotonNetwork.ConnectUsingSettings();
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