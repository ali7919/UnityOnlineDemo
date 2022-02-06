using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpawner : MonoBehaviour {

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    
    private void Start() {
        Vector3 position=new Vector3(Random.Range(-4f,16f),3,3);
        var obj=PhotonNetwork.Instantiate(_playerPrefab.name,position,Quaternion.identity);
        _cinemachineVirtualCamera.Follow = obj.transform.GetChild(0);


    }
}
