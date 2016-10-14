using UnityEngine;
using System.Collections;

public class Shiqu : MonoBehaviour {
    public  string touchname=null;//声明射线碰触到的物体名字变量
    private  GameObject gb;//声明游戏组成对象变量
    private  GameObject gbe;
    private GameObject obj;
    public  GameObject objj;
    private bool cubeflag=false;//声明一个标志位用来判断事件的发生
    private bool sphereflag=false;
    private bool Cylinderflag=false;
    public Texture2D texture;//声明一个Texture2D变量
	void Update () {
        foreach (Touch touch in Input.touches)//对当前触控进行循环
      {
             if(touch.phase==TouchPhase.Began)//判断事件是否有触摸触发
              {
                  Ray ray = Camera.main.ScreenPointToRay(touch.position);//声明有一条由触控点和摄像机组成的射线
                  RaycastHit hit;//声明一个RayCastHit型变量hit
                  if (Physics.Raycast(ray, out hit))//判断此物理事件
                  {
                      touchname = hit.transform.name;//获得射线碰触到物体的名称
                      SetText(touchname);//处理碰触触发事件
                  }
              }
      }           
        
      
        if(sphereflag)//如果sphereflag为真
        {
            gb.transform.Rotate(Time.deltaTime *100,0,0);//开始旋转物体
            gb.transform.position = new Vector3(-2.82f, -1.45f, 3.48f);//使物体位置发生移动
        }
        if(cubeflag)//如果cubeflag为真
        {
            gbe.GetComponent<Renderer>().material.mainTexture = texture;//改变物体的纹理图
        }
        if(Cylinderflag)//如果Cylinderflag为真
        {
            GameObject.Destroy(obj );//销毁该游戏对象
            objj.SetActive(true);//显示另外一个游戏对象
        }
	}
    void SetText(string  cubename)//处理碰触触发事件
    {
        switch (cubename )
        {
            case "Cube"://如果碰触到的是Cube
                gbe  = GameObject.Find("Cube");//找到Scene中的Cube物体
                cubeflag = true;//切换标志位
                break;
            case "Sphere"://如果碰触到的是Sphere
                gb = GameObject.Find("Sphere");//找到Scene中的Sphere物体
                sphereflag = true;
                break;
            case "Cylinder"://如果碰触到的是Cylinder
                 obj   = GameObject.Find("Cylinder");//找到Scene中的Cylinder物体
                 Cylinderflag = true;
                 break;
        }
           
    }
}
