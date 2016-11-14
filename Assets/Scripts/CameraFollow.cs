using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class CameraFollow : NetworkBehaviour {

	public GameObject player;	
    

	void Awake () {
    }
	

    
	// Update is called once per frame
	void FixedUpdate () {

       

        
        Vector3 playerPosition = player.transform.position;

		Vector3 offsetPosition = new Vector3(playerPosition.x, playerPosition.y + 10f, playerPosition.z  -10f);

		transform.position = offsetPosition;
		
		

	}
}
