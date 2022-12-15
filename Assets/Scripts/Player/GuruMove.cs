using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuruMove : MonoBehaviour
{
    private CharacterController controller;
    public GameObject charModel;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerManager.isGameStarted){
            charModel.GetComponent<Animator>().Play("Idle");
            return;
        }
    }
}
