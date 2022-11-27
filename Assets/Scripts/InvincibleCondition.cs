using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleCondition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="PlayerInvincible"){
            Destroy(this.gameObject);
        }
    }
}
