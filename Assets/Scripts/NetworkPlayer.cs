using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour {
    [SyncVar]
    public string playerID;
    public GameObject CameraPrefab;
    GameObject cameraGO;
    public Camera playerCam;
    

    void Awake()
    {
        cameraGO = Instantiate(CameraPrefab) as GameObject;
        cameraGO.GetComponent<CameraFollow>().player = gameObject;
        playerCam = cameraGO.GetComponent<Camera>();
        playerCam.gameObject.SetActive(false);
    }
    [Command]
    void CmdSetPlayerID(string newID)
    {
        playerID = newID;
    }
    public override void OnStartLocalPlayer()
    {
        
        string myPlayerID = string.Format("Player {0}", netId.Value);
        CmdSetPlayerID(myPlayerID);
        playerCam.gameObject.SetActive(true);
    }
}
