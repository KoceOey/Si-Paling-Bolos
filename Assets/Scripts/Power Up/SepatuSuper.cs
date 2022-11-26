using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SepatuSuper : MonoBehaviour
{
    public GameObject charModel;
    private void OnTriggerEnter(Collider other){
        // PlayerManager.gameOver=true;
        PlayerMove.boostSepatuSuper = true;
        Destroy(gameObject);
    }
}
