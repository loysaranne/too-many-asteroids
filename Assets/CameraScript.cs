using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {
        Screen.SetResolution((int)Screen.width, (int)Screen.height, true);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
	}
}
