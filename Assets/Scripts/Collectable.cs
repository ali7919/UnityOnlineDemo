using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Collectable : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Player")) return;

        GetComponent<SphereCollider>().enabled = false;
        var iGotIt = other.gameObject.GetComponent<PhotonView>().IsMine;

        if (GameManager.Instance.Owner) {
            //destroy it
            PhotonNetwork.Destroy(gameObject);
        }
        
        
        GameManager.Instance.CollectableSpawner.OnCollectableDestroyed(transform.position,iGotIt);
    }

}
