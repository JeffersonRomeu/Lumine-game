using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour {

    public SpriteRenderer backGround;

	void Start () {
        Camera.main.fieldOfView = backGround.bounds.size.x * Screen.height / Screen.width * 0.5f;
	}
	
}
