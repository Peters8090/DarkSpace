using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {

    private BoxCollider2D collisionObj1;

	void Start () {	}
	
	void Update () {
        gameObject.GetComponent<RawImage>().rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        
    }
}
