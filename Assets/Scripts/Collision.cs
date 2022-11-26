using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject charModel;
    private void OnTriggerEnter(Collider other){
        // PlayerManager.gameOver=true;
        if(PlayerMove.invincible){
            Destroy(gameObject);
        }else{
            PlayerMove.hit =true;
        }
    }
}
