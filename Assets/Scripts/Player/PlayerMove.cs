using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    private int desiredLane = 1;
    public float laneDistance = 3;
    public float jumpForce;
    public float gravity=-20;
    public GameObject charModel;
    public static bool sideHit;
    public static int hp;
    private int laneHistory;

    void Start(){
        sideHit = false;
        hp=0;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(sideHit){
            desiredLane = laneHistory;
            sideHit = false;
        }
        if(hp >= 2){
            forwardSpeed = 0;
            StumbleBackwards();
        }
        if(!PlayerManager.isGameStarted){
            charModel.GetComponent<Animator>().Play("Idle");
            return;
        }
        if(forwardSpeed<maxSpeed){
            forwardSpeed += 0.2f * Time.deltaTime;
        }
        direction.z = forwardSpeed;
        direction.y+=gravity*Time.deltaTime;
        if(controller.isGrounded){
            //direction.y=-1;
            if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W)){
                Jump();
            }
            if(Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S)){
                Roll();
            }
        }else{
            direction.y+=gravity*Time.deltaTime;
        }
        //kanan
        if(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D)){
            laneHistory = desiredLane;
            desiredLane++;
            if(desiredLane==3){
                desiredLane=2;
            }
        }
        //kiri
        if(Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A)){
            laneHistory = desiredLane;
            desiredLane--;
            if(desiredLane==-1){
                desiredLane=0;
            }
        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        //max lane
        if(desiredLane==0){
            targetPosition+=Vector3.left * laneDistance;
        }else if(desiredLane==2){
            targetPosition+=Vector3.right*laneDistance;
        }
        //transform.position=Vector3.Lerp(transform.position, targetPosition,80 * Time.fixedDeltaTime);
        if(transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if(moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }   

    private void FixedUpdate(){
        if(!PlayerManager.isGameStarted){
            charModel.GetComponent<Animator>().Play("Idle");
            return;
        }
        controller.Move(direction * Time.fixedDeltaTime);
    }
    private void Jump(){
        charModel.GetComponent<Animator>().Play("Jump");
        direction.y=jumpForce;
    }
    private void Roll(){
        charModel.GetComponent<Animator>().Play("roll");
    }
    private void StumbleBackwards(){
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
    }
    // private void OnControllerColliderHit(ControllerColliderHit hit){
    //     if(hit.transform.tag=="Obstacle"){
    //         PlayerManager.gameOver=true;
    //     }
    // }
}
