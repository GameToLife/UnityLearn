using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIMng : Singleton<UIMng>
{
    public class UIInfo
    {
        public UIType uiType { get; private set; }
        public string path { get; private set; }
        public object[] parames { get; private set; }


        public UIInfo(UIType _uiType, string _path, params object[] _parames) 
        {
            uiType = _uiType;
            path = _path;
            parames = _parames;         
            
        }       

    }

    
    protected Dictionary<UIType, GameObject> openingUIsDic = null;
    protected Stack<UIInfo> OpenUIDatasStack = null;

    public override void Init()
    {
        openingUIsDic = new Dictionary<UIType, GameObject>();
        OpenUIDatasStack = new Stack<UIInfo>();
    }

    #region 获取UI
    #endregion

    #region 加载UI

    public void OpenUI(UIType _uitypes, params object[] _paramesObjs)
    {
        UIType[] uitypes = new UIType[1];
        uitypes[0] = _uitypes;

        LoadingUI(false, uitypes, _paramesObjs);
    }     

    public void OpenUI(UIType[] _uitypes) 
    {
        LoadingUI(false, _uitypes, null);
    }

    public void OpenUICloseOthers(UIType _uitypes, params object[] _paramesObjs)
    {
        UIType[] uitypes = new UIType[1];
        uitypes[0] = _uitypes;

        LoadingUI(true, uitypes, _paramesObjs);
    }

    public void OpenUICloseOthers(UIType[] _uitypes) 
    {
        LoadingUI(true, _uitypes, null);
    } 

    private void LoadingUI(bool _isCloseOthers,UIType[] uitypes,params object[] _paramesObjs) 
    {
        if (_isCloseOthers)
        {
            CloseAllUI();
        }
        for (int i = 0; i < uitypes.Length; i++)
        {
            if (!openingUIsDic.ContainsKey(uitypes[i]))
            {
                string path = ResourcesMng.Instance.GetUIResourcesAlongUIType(uitypes[i]);
                if (!string.IsNullOrEmpty(path))
                {
                    OpenUIDatasStack.Push(new UIInfo(uitypes[i], path, _paramesObjs));
                }
               
            }

            if (OpenUIDatasStack.Count>0)
            {
                StartLoadingUI();
            }
            
        }

    }

    protected void StartLoadingUI() 
    {
        if (OpenUIDatasStack != null && OpenUIDatasStack.Count > 0)
        {
            UIInfo uiData = OpenUIDatasStack.Pop();
            Object obj = ResourcesMng.Instance.GetResourcesAlongType(ResourcesType.UIType, uiData.path);
            if (obj!=null)
            {
                
                GameObject gameObj = MonoBehaviour.Instantiate(obj) as GameObject;
                UIBase uiBase = gameObj.GetComponent<UIBase>();
                if (uiBase != null)
                {
                    uiBase.SetGameObj();
                }
                else 
                {
                    Debug.LogError("类型为:"+uiData.uiType+"不继承UIBASE");
                }
               
                
                openingUIsDic.Add(uiData.uiType,gameObj);
            }
        }
        else 
        {
            Debug.LogError("OpenUIDatasStack=" + OpenUIDatasStack + "||,OpenUIDatasStack.Count=" + OpenUIDatasStack.Count);
        }
        
    }

    #endregion

    #region 释放UI

    public void CloseUI(UIType[] _types) 
    {
        for (int i = 0; i < _types.Length; i++)
        {
            if (openingUIsDic.ContainsKey(_types[i]))
            {
                CloseUI(_types[i]);
            }
            else 
            {
                Debug.LogError("!openingUIsDic.ContainsKey(_types[i]):" + _types[i]);
            }
        }
    }

    public void CloseUI(UIType _type) 
    {
        if (openingUIsDic.ContainsKey(_type))
        {
            CloseUI(_type, openingUIsDic[_type]);
        }
        else
        {
            Debug.LogError("!openingUIsDic.ContainsKey(_types[i]):" + _type);
        }
    }

    public void CloseAllUI() 
    {
        List<UIType> keyList = new List<UIType>(openingUIsDic.Keys);
        for (int i = 0; i < keyList.Count; i++)
        {
            CloseUI(keyList[i]);
        }
    }

    private void CloseUI(UIType _type,GameObject _obj) 
    {
        if (_obj == null)
        {
            openingUIsDic.Remove(_type);
        }
        else 
        {
            GameObject.Destroy(_obj);
            openingUIsDic.Remove(_type);
        }
    }


    #endregion

}
