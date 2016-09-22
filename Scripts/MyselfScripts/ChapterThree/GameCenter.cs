using UnityEngine;
using System.Collections;

public class GameCenter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
