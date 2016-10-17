using UnityEngine;
using System.Collections;

public class CameraRot 
    : MonoBehaviour {
    private Vector3 aimpos;
    private Vector3 mousepos;
    private bool hdflag = true;//true横向 false纵向

	// Use this for initialization
	void Start () {
        aimpos = new Vector3(-1.3f,7.4f,9.5f);
        hdflag = true;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(transform.forward);
	    if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Moved)
        {
            Vector2 touchDeltaPos = Input.GetTouch(0).deltaPosition;
            if (Mathf.Abs(touchDeltaPos.x) > 10)//横向滑动
            {
                hdflag = true;
                //Debug.Log("------");
            }else
            if (Mathf.Abs(touchDeltaPos.y) > 10)//纵向滑动
            {
                hdflag = false;
                //Debug.Log("lllll");
            }
            if (hdflag)
            {
                transform.RotateAround(aimpos, Vector3.up, -1 * touchDeltaPos.x * 0.1f);
            }
            else
            {
                if (transform.forward.x > -0.4f || transform.forward.x < -0.9f)
                {
                    return;
                }
                if (transform.position.x > -4.5f && touchDeltaPos.y>0)
                {
                    transform.Translate(new Vector3(0, 0, touchDeltaPos.y * 0.05f), Space.Self);
                }
                if (transform.position.x < 3.6f && touchDeltaPos.y < 0)
                {
                    transform.Translate(new Vector3(0, 0, touchDeltaPos.y * 0.05f), Space.Self);
                }
            }
        }
	    if(Input.GetKeyUp(KeyCode.Escape))
        {		                            //"返回"按键监听
	        Application.Quit();					//退出游戏
	    }
    }
}
