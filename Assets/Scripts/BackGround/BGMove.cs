using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour {
    private GameObject gmo, bck_finish, bck_start;
    private Vector3 oldPosition;
    private bool chk = true;
    public float moveSpeed;
    public float moveRange;    
	// Use this for initialization
	void Start () {
        gmo = gameObject;
        bck_start = GameObject.FindGameObjectWithTag("Start");
        bck_finish = GameObject.FindGameObjectWithTag("Finish");
        moveSpeed = 4;
        moveRange = 6;

        //Scale background to full screen
        #region
        GameObject[] lst_gmo;
        float sc = Screen.width / 100 * 0.805f / gmo.GetComponent<SpriteRenderer>().bounds.size.x;
        GameObject.FindGameObjectWithTag("Car").transform.localScale = new Vector3(sc, sc, 1);
        lst_gmo = GameObject.FindGameObjectsWithTag("Barrier");
        
        for(int i = 0; i < lst_gmo.Length; i++)
            lst_gmo[i].transform.localScale = new Vector3(sc, sc, 1);

        //.transform.localScale = new Vector3(sc, sc, 1);
        //gmo.transform.localScale = new Vector3(sc, sc, 1);

        //test 
        gmo.transform.localScale = new Vector3(sc, sc + 0.2f, 1);
        //

        Vector3 pos = transform.position;
        pos.y = gmo.GetComponent<SpriteRenderer>().bounds.size.y / 2 - Camera.main.orthographicSize;
        gmo.transform.position = pos;
        #endregion
        //end

        bck_finish.transform.position = new Vector3(gmo.transform.position.x, gmo.transform.position.y + gmo.GetComponent<SpriteRenderer>().bounds.size.y, 0);

        oldPosition = gmo.transform.position;
        GameObject.FindGameObjectWithTag("Barrier_start").transform.position = new Vector3(0, pos.y - bck_start.GetComponent<SpriteRenderer>().bounds.size.y / 2 - 1, 0);
        GameObject.FindGameObjectWithTag("Barrier_finish").transform.position = new Vector3(0, pos.y + bck_start.GetComponent<SpriteRenderer>().bounds.size.y / 2 + 3, 0);
    }

    //Update is called once per frame
        void Update()
    {
        gmo.transform.Translate(new Vector3(gmo.transform.position.x, -1 * moveSpeed * Time.deltaTime, 0));

        if (chk)
        {
            if (Vector3.Distance(bck_start.transform.position, oldPosition) >= bck_start.GetComponent<SpriteRenderer>().bounds.size.y)
            {
                //gmo.transform.position = bck2.transform.position + gmo.GetComponent<SpriteRenderer>().bounds.size.y;
                bck_start.transform.position = new Vector3(bck_finish.transform.position.x, bck_finish.transform.position.y + bck_finish.GetComponent<SpriteRenderer>().bounds.size.y, 0);
                chk = false;
            }
        }
        else
        {
            if (Vector3.Distance(bck_finish.transform.position, oldPosition) >= bck_finish.GetComponent<SpriteRenderer>().bounds.size.y)
            {
                //gmo.transform.position = bck2.transform.position + gmo.GetComponent<SpriteRenderer>().bounds.size.y;
                bck_finish.transform.position = new Vector3(bck_start.transform.position.x, bck_start.transform.position.y + bck_start.GetComponent<SpriteRenderer>().bounds.size.y, 0);
                chk = true;
            }
        }
    }
}
