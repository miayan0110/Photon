using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotonChatManager : MonoBehaviour, IChatClientListener
{
    ChatClient chatClient;
    bool isConnected = false;

    [SerializeField] string username;
    string chatMessage;
    string messageReceiver = "";
    [SerializeField] GameObject joinChatBtn;
    [SerializeField] GameObject chatRoom;
    [SerializeField] TMP_InputField messageInputField;
    [SerializeField] TMP_Text messagesDisplay;
    [SerializeField] GameObject loadingText;

    /// <summary>
    /// 取得玩家名稱
    /// </summary>
    /// <param name="inputName"></param>
    public void OnUsernameValueChange(string inputName)
    {
        username = inputName;
    }

    /// <summary>
    /// 連線至聊天室
    /// </summary>
    public void OnJoinChatBtnClick()
    {
        isConnected = true;
        chatClient = new ChatClient(this);
        // chatClient.ChatRegion = "asia";
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(username));
        Debug.Log("Connecting...");
    }

    /// <summary>
    /// 取得訊息
    /// </summary>
    /// <param name="message"></param>
    public void OnChatMessageValueChange(string message)
    {
        chatMessage = message;
    }

    /// <summary>
    /// 取得接收私訊玩家名稱
    /// </summary>
    /// <param name="receiver"></param>
    public void OnReceiverValueChange(string receiver)
    {
        messageReceiver = receiver;
    }

    /// <summary>
    /// 送出訊息
    /// </summary>
    public void OnSendBtnClick()
    {
        if (messageReceiver == "")
        {
            SendPublicMessages();
        }
        else
        {
            SendPrivateMessages();
        }
    }

    /// <summary>
    /// 發送公開訊息
    /// </summary>
    private void SendPublicMessages()
    {
        chatClient.PublishMessage("DefaultChannel", chatMessage);
        messageInputField.text = "";
        chatMessage = "";
    }

    /// <summary>
    /// 發送私人訊息
    /// </summary>
    private void SendPrivateMessages()
    {
        chatClient.SendPrivateMessage(messageReceiver, chatMessage);
        messageInputField.text = "";
        chatMessage = "";
    }


    #region Unity 控制

    void Start()
    {
        username = CharacSelector.characID;

        loadingText.SetActive(true);
        //joinChatBtn.SetActive(true);
        //chatRoom.SetActive(false);

        OnJoinChatBtnClick();
        
    }

    void Update()
    {
        if (isConnected)
        {
            chatClient.Service();
        }

        if (messageInputField.text != "" && Input.GetKey(KeyCode.Return))
        {
            OnSendBtnClick();
        }
    }

    #endregion

    #region 實作Interface

    public void DebugReturn(DebugLevel level, string message)
    {
        //Debug.Log("TODO: Debug Return");
        //throw new System.NotImplementedException();
    }

    public void OnChatStateChange(ChatState state)
    {
        //Debug.Log("TODO: OnChatStateChange");
        //throw new System.NotImplementedException();
    }

    public void OnConnected()
    {
        Debug.Log("Connected.");
        loadingText.SetActive(false);
        joinChatBtn.SetActive(false);
        chatClient.Subscribe(new string[] { "DefaultChannel" });
    }

    public void OnDisconnected()
    {
        //Debug.Log("TODO: OnDisconnected");
        //throw new System.NotImplementedException();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        string msgs = "";
        for(int i = 0; i < senders.Length; i++)
        {
            string senderNickName = senders[i] == username ? "我" : senders[i];
            msgs = string.Format("{0}: {1}", senderNickName, messages[i]);
            
            messagesDisplay.text += "\n" + msgs;
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        string msgs = "";
        string senderNickName = sender == username ? "我" : sender;
        msgs = string.Format("{0}: {1}", senderNickName, message);
        messagesDisplay.text += "\n" + msgs;
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        chatRoom.SetActive(true);
    }

    public void OnUnsubscribed(string[] channels)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
