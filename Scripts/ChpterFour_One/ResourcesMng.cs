using UnityEngine;
using System.Collections;
using System.Text;

public class ResourcesMng : Singleton<ResourcesMng>
{

    protected static string UIPath = "UI/";

    public Object GetResourcesAlongType(ResourcesType _type,string _name) 
    {
        
        Object resourcesObj = null;
        StringBuilder stringBuilder = new StringBuilder();
        
        switch (_type)
        {
            case ResourcesType.None:
                break;
            case ResourcesType.UIType:
                stringBuilder.Append(UIPath).Append(_name);
                resourcesObj = Resources.Load(stringBuilder.ToString());
                break;
            default:
                break;
        }
        if (resourcesObj == null || string.IsNullOrEmpty(stringBuilder.ToString()))
        {
            Debug.LogError("到不到路径为:" + stringBuilder+",类型为:"+_type+"的资源");
        }
        return resourcesObj;
    }


    public string GetUIResourcesAlongUIType(UIType _type)
    {
        StringBuilder stringBuilder = new StringBuilder();

        switch (_type)
        {
            case UIType.None:
                break;
            case UIType.TestOne:
                stringBuilder.Append("TestOne");
                break;
            case UIType.TestTwo:
                stringBuilder.Append("TestTwo");
                break;
            case UIType.RockerTouch:
                stringBuilder.Append("RockerTouch");
                break;
            case UIType.ClickUI:
                stringBuilder.Append("ClickUI");
                break;
                
            default:
                break;
        }
        if (string.IsNullOrEmpty(stringBuilder.ToString()))
        {
            Debug.LogError("类型为:"+_type+ "的空路径:" + stringBuilder);
        }
        return stringBuilder.ToString();
    }

}
