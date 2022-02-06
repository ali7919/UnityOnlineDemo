using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start() {
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby();
    }
    
    public override void OnJoinedLobby() {
        SceneManager.LoadScene(1);
    }
    
    
    

}
