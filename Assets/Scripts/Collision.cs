using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject charModel;
    private void OnTriggerEnter(Collider other){
        // PlayerManager.gameOver=true;
        if(other.gameObject.tag=="PlayerInvincible"){
            Destroy(this.gameObject);
        }else{
            PlayerMove.hit =true;
        }
    }
}
