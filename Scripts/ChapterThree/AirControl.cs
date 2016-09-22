using UnityEngine;
using System.Collections;

public class AirControl : MonoBehaviour
{

    private Transform m_transform;          //保存Transform实例 
    public float speed = 50f;      //飞机的飞行速度
    private float rotationz = 0.0f;         //绕Z轴的旋转量
    public float rotateSpeed_AxisZ = 45f;   //绕Z轴的旋转速度
    public float rotateSpeed_AxisY = 20f;   //绕Y轴的旋转速度
    private float screenWeight;             //屏幕宽度
    private Vector2 touchPosition;          //触摸点坐标


    // Use this for initialization
    void Start()
    {
        m_transform = this.transform;       //赋值，减少外部代码的调用       
        this.gameObject.GetComponent<Rigidbody>().useGravity = false; //默认不受重力影响
        screenWeight = Screen.width;        //获取屏幕宽度
    }

    // Update is called once per frame
    void Update()
    {
        m_transform.Translate(new Vector3(0, 0, speed / 20 * Time.deltaTime));//向前移动
        // 寻找到名称为“propeller”的对象并使其绕Y轴旋转
        GameObject.Find("propeller").transform.Rotate(new Vector3(0, 100f, 0));


        // 获取飞机对象绕X轴的旋转量
        rotationz = this.transform.eulerAngles.z;

        //----------------触摸监听开始-----------------//
        if (Input.touchCount > 0) {         //当触摸的数量大于0
            for (int i = 0; i < Input.touchCount; i++) {
                Touch touch = Input.touches[i];        //实例化当前触摸点

                // 手指在屏幕上没有移动或发生滑动时触发的事件
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
                    // 获取当前触摸点坐标
                    touchPosition = touch.position;
                    // 触摸点在屏幕左半侧
                    if (touchPosition.x < screenWeight / 2) {
                        if ((rotationz <= 45 || rotationz >= 315)) {
                            // 飞机向左倾斜
                            m_transform.Rotate(new Vector3(0, 0, (Time.deltaTime * rotateSpeed_AxisZ)), Space.Self);
                        }
                        // 飞机左转
                        m_transform.Rotate(new Vector3(0, -Time.deltaTime * 30, 0), Space.World);
                    }
                    // 触摸点在屏幕右半侧
                    else if (touchPosition.x >= screenWeight / 2) {
                        if ((rotationz <= 45 || rotationz >= 315)) {
                            // 飞机向右倾斜
                            m_transform.Rotate(new Vector3(0, 0, (Time.deltaTime * -rotateSpeed_AxisZ)), Space.Self);
                        }
                        // 飞机右转
                        m_transform.Rotate(new Vector3(0, Time.deltaTime * 30, 0), Space.World);
                    }
                }
                // 手指离开屏幕时触发的事件
                else if (touch.phase == TouchPhase.Ended) {

                    BackToBlance();     //调用恢复平衡状态方法
                }
            }
        }

        if (Input.touchCount == 0) {    //当没有手指触摸屏幕时

            BackToBlance();             //调用恢复平衡状态方法
        }
        //----------------触摸监听结束-----------------//

        //判断当前运行平台为Android平台
        if (Application.platform == RuntimePlatform.Android) {

            if (Input.GetKeyDown(KeyCode.Home)) {     //触发Hmoe按钮
                Application.Quit();                 //退出程序
            }
            if (Input.GetKeyDown(KeyCode.Escape)) {   //触发返回按钮
                Application.Quit();                 //退出程序
            }
        }
    }

    void BackToBlance()                 //恢复平衡方法
    {
        if ((rotationz <= 180)) {       //判断如果飞机为右倾状态
            if (rotationz - 0 <= 2) {   //在阈值内轻微晃动
                m_transform.Rotate(0, 0, Time.deltaTime * -1);
            }
            else {                      //快速恢复平衡状态
                m_transform.Rotate(0, 0, Time.deltaTime * -40);
            }
        }

        if ((rotationz > 180)) {        //判断如果飞机为左倾状态
            if (360 - rotationz <= 2) { //在阈值内轻微晃动
                m_transform.Rotate(0, 0, Time.deltaTime * 1);
            }
            else {                      //快速恢复平衡状态
                m_transform.Rotate(0, 0, Time.deltaTime * 40);
            }
        }
    }
}
