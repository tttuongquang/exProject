using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMove : MonoBehaviour {
    private GameObject gmo, bck_finish, bck_start;
    private Vector3 oldPosition;
    private bool chk = true;
    public float moveSpeed;
    public Sprite[] lst_defaut;
    // Use this for initialization
    void Start()
    {
        //gmo = GameObject.FindGameObjectWithTag("Barrier");
        gmo = gameObject;
        moveSpeed = 2.5f;

        bck_start = GameObject.FindGameObjectWithTag("Barrier_start");
        bck_finish = GameObject.FindGameObjectWithTag("Barrier_finish");

        //gmo.transform.position = new Vector3(gmo.transform.position.x, bck_finish.transform.position.y, 0);

        Debug.Log(GameObject.FindGameObjectWithTag("Car").GetComponent<SpriteRenderer>().bounds.size.y * 2 + gmo.transform.position.y);
        Debug.Log(gmo.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        gmo.transform.Translate(new Vector3(0, -1 * moveSpeed * Time.deltaTime, 0));

        if (Vector3.Distance(bck_start.transform.position, gmo.transform.position) >= gmo.GetComponent<SpriteRenderer>().bounds.size.y / 2 && bck_start.transform.position.y > gmo.transform.position.y)
        {
            Destroy(gmo.GetComponent("PolygonCollider2D"));
            //bck_start.transform.position = new Vector3(bck_finish.transform.position.x, bck_finish.transform.position.y + bck_finish.GetComponent<SpriteRenderer>().bounds.size.y, 0);
            gmo.transform.position = new Vector3(gmo.transform.position.x, bck_finish.transform.position.y, 0);
            gmo.GetComponent<SpriteRenderer>().sprite = lst_defaut[Random.Range(0, 43)];
            gmo.AddComponent<PolygonCollider2D>();
        }
    }
}
