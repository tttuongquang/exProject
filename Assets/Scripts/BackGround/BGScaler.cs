using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float sc = Screen.width / 100 * 0.805f / GetComponent<SpriteRenderer>().bounds.size.x;
        GameObject.FindGameObjectWithTag("Car").transform.localScale = new Vector3(sc, sc, 1);
        transform.localScale = new Vector3(sc, sc, 1);

        Vector3 pos = transform.position;
        pos.y = GetComponent<SpriteRenderer>().bounds.size.y / 2 - Camera.main.orthographicSize - 1;
        transform.position = pos;

        GameObject.FindGameObjectWithTag("Finish").transform.position = new Vector3(transform.position.x, transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
