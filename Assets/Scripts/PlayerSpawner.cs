using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] _playerPrefabs;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private Transform _spawnPoint;
    
    private void Start() {
	Cursor.visible = false;
    var position1 = _spawnPoint.position;
    Vector3 position=new Vector3(position1.x,position1.y,Random.Range(position1.z,position1.z+5));
        var obj=PhotonNetwork.Instantiate(_playerPrefabs[CharacterSelectSceneManager.TYPE].name,position,Quaternion.identity);
        _cinemachineVirtualCamera.Follow = obj.transform.GetChild(0);


    }
}
