using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour {
    [SerializeField] private Collectable _collectablePrefab;
    [SerializeField] private TextMeshProUGUI _scoreTV;
    [SerializeField] private Transform[] _spawnPoints;
    private int _score;

    void Start() {
        GameManager.Instance.CollectableSpawner = this;
        SpawnCollectable(new Vector3(0, 0, 0));
    }

    public void SpawnCollectable(Vector3 lastPosition) {
        if (!GameManager.Instance.Owner) return;

        //get the new position
        int index = -1;
        do {
            index = Random.Range(0, _spawnPoints.Length);
        } while (_spawnPoints[index].position == lastPosition);


        Vector3 position = _spawnPoints[index].position;


        //Instantiate collectable 
        Collectable collectable = PhotonNetwork.Instantiate(_collectablePrefab.name, position, Quaternion.identity)
            .GetComponent<Collectable>();

    }

    public void OnCollectableDestroyed(Vector3 position,bool iGotIt) {
        SpawnCollectable(position);
        if (!iGotIt) {
            return;
        }
        _score++;
        _scoreTV.SetText(_score.ToString());
    }


}