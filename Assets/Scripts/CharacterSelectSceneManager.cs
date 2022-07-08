using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectSceneManager : MonoBehaviour {
    public static int TYPE;



    public void OnCharacterSelected(int type) {
        TYPE = type;
        SceneManager.LoadScene(1);

        
    }
}
