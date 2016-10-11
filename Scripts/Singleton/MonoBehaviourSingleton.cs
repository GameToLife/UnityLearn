using UnityEngine;
using System.Collections;

public class MonoBehaviourSingleton<T> : MonoBehaviour where  T:MonoBehaviourSingleton<T>{

    private static T instance = null;

    public static T Instance 
    {
        get 
        {
            if (instance==null)
            {
                GameObject tempObj = GameObject.Find("MonoBehaviourSingleton");
                if (tempObj==null)
                {
                    tempObj = new GameObject("MonoBehaviourSingleton");
                    DontDestroyOnLoad(tempObj);
                }
                instance = tempObj.AddComponent<T>();
            }
            return instance;
        }
    }

    private void OnApplicationQuit() 
    {
        instance = null;
    }
}
