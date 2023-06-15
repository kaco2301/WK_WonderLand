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
        Screen.SetResolution(960, 600, false); // �ػ� ����
        PhotonNetwork.ConnectUsingSettings(); // ���� ���� ����
        p_InputField = GameObject.Find("Canvas/InputField").GetComponent<InputField>();
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions(); // �� �ɼ� ����
        options.MaxPlayers = 5; // �ִ� �ο�

        PhotonNetwork.LocalPlayer.NickName = p_InputField.text;
        PhotonNetwork.JoinOrCreateRoom("Romm1", options, null); // �� ������ ����, ������ �� ���� ����
    }

    public override void OnJoinedRoom()
    {
        updatePlayer();
        Debug.Log(p_InputField + " ���� �����ϼ̽��ϴ�.");
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void updatePlayer()
    {
        for(int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            Debug.Log("�÷��̾� ����");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
