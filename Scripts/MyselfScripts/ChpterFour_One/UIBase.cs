using UnityEngine;
using System.Collections;

public class UIBase : MonoBehaviour {

    private GameObject obj=null;
    public GameObject Obj 
    {
        get 
        {
            if (obj==null)
            {
                obj = this.gameObject;
            }
            return obj;
        }
    }

    private Transform parentTransform =null;
    protected Transform ParentTransform 
    {
        get 
        {
            if (parentTransform == null) 
            {
                GameObject parentObj = GameObject.Find("UI Root");
                if (parentObj != null)
                {
                    parentTransform = parentObj.transform;
                }
                else
                {
                    Debug.LogError("parentObj = null");
                }
            }
            return parentTransform;          
        }
    }


    void Awake() 
    {
        OnAwake();
    }   
	
	void Start () 
    {
        OnStart();
	}

    public virtual void OnAwake() { }
    public virtual void OnStart() { }

    public void SetGameObj() 
    {
        Obj.SetActive(true);
        UIAnchor uiAnchor = Obj.GetComponent<UIAnchor>();
        if (uiAnchor == null)
        {
            Obj.AddComponent<UIAnchor>();
        }
        
        Obj.transform.parent = ParentTransform;
        Obj.transform.localScale = Vector3.one;
        Obj.transform.localPosition = Vector3.zero;
        
    }

}
