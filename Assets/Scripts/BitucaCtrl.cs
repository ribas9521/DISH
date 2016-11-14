using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class BitucaCtrl : NetworkBehaviour { 

	Animator anim;
	Rigidbody playerRb;
    public GameObject fireBallPrefab;
    GameObject shotSpot;
	
	// Use this for initialization
	void Awake () {
		anim = GetComponentInChildren<Animator>();
		playerRb = GetComponent<Rigidbody>();
        shotSpot = transform.FindChild("ShotSpot").gameObject;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isLocalPlayer)
			return;

		if (Input.GetButtonDown("Fire2"))
			CmdAttack2();
        if (Input.GetButtonDown("Fire1"))
            CmdFireBall();
    }


	[Command]
	void CmdAttack2()
	{    
			   
		RpcAttack2();

	}

	[ClientRpc]
	void RpcAttack2()
	{
		anim.SetTrigger("AnyToHit2");    
		

	}

    [Command]
    void CmdFireBall()
    {
        var fireBall = (GameObject)Instantiate(fireBallPrefab, shotSpot.transform.position, shotSpot.transform.rotation);
        NetworkServer.SpawnWithClientAuthority(fireBall, gameObject);
    }

    [ClientRpc]
    void RpcFireBall()
    {
       
    }
}
