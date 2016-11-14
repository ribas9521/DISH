using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;


public class GameManagerCtrl : NetworkBehaviour{

    
    List<GameObject> playersList;
    List<GameObject> camerasList;
    
	
	void Start () {
       
        playersList = new List<GameObject>();
        camerasList = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        

	}

    public void listPlayers(GameObject player)
    {
        playersList.Add(player);      
       
        

    }
    public void listCameras(GameObject camera)
    {
        camerasList.Add(camera);
       
    }
    public List<GameObject> getListPlayers()
    {
        
        return playersList;       
    }
    public List<GameObject> getListCameras()
    {
        
        return camerasList;
    }
}
