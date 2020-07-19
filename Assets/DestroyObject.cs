using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
    GameObject maincamera;

	// Use this for initialization
	void Start () {
        //シーン中のunitychanオブジェクトを取得
        maincamera = GameObject.Find("Main Camera");
        this.gameObject.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if(this.transform.position.z < maincamera.transform.position.z)
        // このスクリプトがアタッチされているオブジェクトを破棄
        Destroy(this.gameObject);
    }
}
