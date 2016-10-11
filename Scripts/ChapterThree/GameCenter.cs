using UnityEngine;
using System.Collections;

public class GameCenter : MonoBehaviour {

    public Camera uiCamera;
    public Camera mainCamera;
    public Boat boat;
    public Catch catchObj;
    public GameObject testRotation;

    public static GameCenter instance=null;


	// Use this for initialization
	void Start () {
        instance = this;
        UIMng.Instance.OpenUI(UIType.RockerTouch);
        UIMng.Instance.OpenUI(UIType.ClickUI);
	}
	
	// Update is called once per frame
	void Update () 
    {
        ExitGame();
	}

    void ExitGame() 
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            if (Input.GetKeyDown(KeyCode.Home))
            {     
                Application.Quit();                 
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {   
                Application.Quit();                
            }
        }
    }
}
