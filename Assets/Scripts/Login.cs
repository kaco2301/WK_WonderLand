using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Login : MonoBehaviourPunCallbacks
{
    InputField p_InputField;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(960, 600, false); // 해상도 설정
        PhotonNetwork.ConnectUsingSettings(); // 포톤 연결 설정
        p_InputField = GameObject.Find("Canvas/InputField").GetComponent<InputField>();
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions(); // 방 옵션 설정
        options.MaxPlayers = 5; // 최대 인원

        PhotonNetwork.LocalPlayer.NickName = p_InputField.text;
        PhotonNetwork.JoinOrCreateRoom("Romm1", options, null); // 방 있으면 입장, 없으면 방 만들어서 입장
    }

    public override void OnJoinedRoom()
    {
        updatePlayer();
        Debug.Log(p_InputField + " 님이 입장하셨습니다.");
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void updatePlayer()
    {
        for(int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            Debug.Log("플레이어 접속");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
