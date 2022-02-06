using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class LobbySceneManager : MonoBehaviourPunCallbacks {
    [SerializeField] private TMP_InputField _inputField;


    public void Create() {
        GameManager.Instance.Owner = true;
        PhotonNetwork.CreateRoom(_inputField.text);
    }


    public void Join() {
        GameManager.Instance.Owner = false;
        PhotonNetwork.JoinRoom(_inputField.text);
    }

    public override void OnJoinedRoom() => PhotonNetwork.LoadLevel(2);

    public override void OnJoinRoomFailed(short returnCode, string message) {
        Debug.Log(message);
    }
}