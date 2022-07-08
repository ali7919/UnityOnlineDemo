using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class LobbySceneManager : MonoBehaviourPunCallbacks {
    [SerializeField] private TMP_InputField _inputField;

    [SerializeField] private GameObject _connecting, _inputViews,_error;


    private void Awake() {
        _connecting.SetActive(false);
        _error.SetActive(false);

    }

    public void Create() {
        OnConnect();
        GameManager.Instance.Owner = true;
        PhotonNetwork.CreateRoom(_inputField.text);
    }

    private void OnConnect() {
        _inputViews.SetActive(false);
        _connecting.SetActive(true);
        _error.SetActive(false);
    }


    public void Join() {
        OnConnect();
        GameManager.Instance.Owner = false;
        PhotonNetwork.JoinRoom(_inputField.text);
    }

    public override void OnJoinedRoom() => PhotonNetwork.LoadLevel(2);

    public override void OnJoinRoomFailed(short returnCode, string message) {
        StartCoroutine(ShowError());
        _inputViews.SetActive(true);
        _connecting.SetActive(false);
    }


    IEnumerator ShowError() {
        _error.SetActive(true);
        yield return new WaitForSeconds(2);
        
        _error.SetActive(false);
    }
}