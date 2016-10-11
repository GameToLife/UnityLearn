using UnityEngine;
using System.Collections;

/// <summary>
/// 单例类
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T>  where T: class ,new() {

    protected static T instance=null;

    public static T Instance 
    {
        get 
        {
            
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }


    protected Singleton() 
    {
        if (instance!=null)
        {
            Debug.LogError("it had a same instance");
            
        }
        Init();
    }

    public virtual void Init() { }
}
