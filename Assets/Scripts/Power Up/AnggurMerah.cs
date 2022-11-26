using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnggurMerah : MonoBehaviour
{
    public GameObject charModel;
    private void OnTriggerEnter(Collider other){
        // PlayerManager.gameOver=true;
        PlayerMove.boostAnggurMerah = true;
        Destroy(gameObject);
    }
}
