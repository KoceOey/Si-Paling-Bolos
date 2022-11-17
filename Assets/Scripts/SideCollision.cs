using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCollision : MonoBehaviour
{
    public GameObject charModel;
    private void OnTriggerEnter(Collider other){
        // PlayerManager.gameOver=true;
        PlayerMove.hp += 1;
        PlayerMove.sideHit = true;
    }
}
