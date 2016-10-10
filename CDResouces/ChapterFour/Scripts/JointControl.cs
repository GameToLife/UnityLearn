using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JointControl : MonoBehaviour {
    public Transform[] claws0;          //爪子一级支节
    public Transform[] claws1;          //爪子二级支节
    public Transform[] claws2;          //爪子三级支节
    private float angle;                //爪子打开或合拢的角度
    private float offset;               //角度步长
    public Transform Line;              //绳子对象
    private Vector3 offsetPosition;     //绳子移动步长
    private Vector3 rotateAxis;         //绳子旋转轴
    private bool isMove;                //绳子移动标志位
    private bool isRota;                //绳子旋转标志位
    void Start () {
        InitUI();           //初始化UI，进行屏幕自适应
        angle = 0;          //默认爪子为开启
    }
    void Update () {
        if (angle + offset >= 0 && angle + offset < 20) {                   //爪子可进行操作
            for (int i = 0; i < 4; i++) {                                   //进行开启或合拢
                claws0[i].Rotate(Vector3.left, offset * 2.5f, Space.Self);  //三级支节分别进行操作
                claws1[i].Rotate(Vector3.left, offset * 0.2f, Space.Self);
                claws2[i].Rotate(Vector3.left, offset * 1.8f, Space.Self);
            }
            angle += offset;
        }
        if (isMove) {                       //移动绳子
            Line.position = Vector3.Lerp(Line.position, Line.position + offsetPosition * 1.2f, Time.deltaTime * 1.2f);
        }
        if (isRota) {                       //旋转绳子
            Line.Rotate(rotateAxis, 5);
        }
    }
    public void ControlCatcher(int i) {     //开启或合拢爪子监听方法
        offset = i == 1 ? -0.2f : 0.2f;
    }
    public void MoveCatcher(int i) {        //移动绳子监听方法
        Vector3[] poses = new Vector3[6] {Vector3.forward, Vector3.back, Vector3.left, Vector3.right, Vector3.up, Vector3.down};
        offsetPosition = poses[i];
        isMove = true;
    }
    public void RotateCatcher(int i) {      //旋转绳子监听方法
        Vector3[] rotas = new Vector3[2] { Vector3.forward, Vector3.back };
        rotateAxis = rotas[i];
        isRota = true;
    }
    public void MoveButtonUp() {            //按钮抬起监听方法
        isMove = false;
        isRota = false;
    }
    private void InitUI() {                 //UI按钮屏幕自适应方法
        Vector2 editScreen = new Vector2(593, 327);
        Transform canvas = GameObject.Find("Canvas").transform;         //在Canvas下的对象将进行位置和大小的调整
        Vector2 scaleExchange = new Vector2(Screen.width / editScreen.x, Screen.height / editScreen.y);
        for (int i = 0; i < canvas.childCount; i++) {
            RectTransform canvasChildRT = canvas.GetChild(i).GetComponent<RectTransform>();
            canvasChildRT.position = new Vector3(scaleExchange.x * canvasChildRT.position.x,    //调整其位置
                                                 scaleExchange.y * canvasChildRT.position.y,
                                                 0);
            canvasChildRT.sizeDelta = new Vector3(scaleExchange.x * canvasChildRT.sizeDelta.x,    //调整其缩放比
                                                   scaleExchange.y * canvasChildRT.sizeDelta.y,
                                                   1);
        }
    }
}