using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MovementCtrl : NetworkBehaviour {

    public float speed = 6f;
    Rigidbody PlayerRb;
    Vector3 movement;
    NetworkPlayer networkPlayer;
    Camera cam;    
    int floorMask;
    Animator anim;
    

    // Use this for initialization
    void Awake () {
        PlayerRb = GetComponentInChildren<Rigidbody>();
        networkPlayer = GetComponent<NetworkPlayer>();        
        floorMask = LayerMask.GetMask("Raycast");
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        cam = networkPlayer.playerCam;
    }
       

    // Update is called once per frame
    void FixedUpdate () {
        if (!isLocalPlayer)
            return;
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        

        move(h, v);
        jump();
        turn();
        CmdAnimate(h, v);
        

        
    }

    void move(float h, float v)
    {       

        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        PlayerRb.MovePosition(transform.position + movement);
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRb.AddForce(0f, 500f, 0f);
            
        }
    }

    void turn()
    {

        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if(Physics.Raycast(camRay, out floorHit, 1000f, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse*.1f);
            PlayerRb.MoveRotation(newRotation);
        }
        
    }
    [Command]
    void CmdAnimate(float h, float v) {
        
        RpcAnimate(h, v);
    }

    [ClientRpc]
    void RpcAnimate(float h, float v)
    {
        bool running = h != 0f || v != 0f;
        anim.SetBool("param_idletorunning", running);
    }
   

    
}
