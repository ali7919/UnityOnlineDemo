using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviourPunCallbacks {
    [SerializeField] private GameObject _menu;

    private bool _shown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            _shown = !_shown;
            _menu.SetActive(_shown);

            Cursor.visible = _shown;
            Cursor.lockState = _shown?CursorLockMode.None:CursorLockMode.Locked;
        }
    }
    public void OnBack() {
        
        PhotonNetwork.LeaveRoom();
        
    }

    public override void OnLeftRoom() {

        SceneManager.LoadScene(3);

    }


    public void OnExit() {
            Application.Quit();
    }
}
