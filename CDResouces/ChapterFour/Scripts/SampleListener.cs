using UnityEngine;
using System.Collections;
public class SampleListener : MonoBehaviour {
    public GameObject ballPre;
    public Transform targetPos;
    public Cloth cloth;
    private int icount;
    public GameObject FireFlare;
    void Start () {
        InitUI();               //屏幕自适应
    }
    public void Fire() {
        Rigidbody ballRi = ((GameObject)(Instantiate(ballPre, targetPos.position, targetPos.rotation))).GetComponent<Rigidbody>();  //实例化炮弹
        ballRi.AddForce((targetPos.position - transform.position) * 500);               //向炮弹施加一个力
        addCollider(ref cloth, ballRi.gameObject.GetComponent<SphereCollider>());       //将自身添加到布料碰撞列表
        BallListener.destoryGameobject.Add((GameObject)Instantiate(FireFlare, targetPos.position, targetPos.rotation));
    }
    public void Update() {
        if (BallListener.destoryGameobject.Count != 0) {                            //检测待销毁对象列表是否为空
            icount++;                                                               //计数器自加
            if (icount > 60) {
                GameObject.Destroy((GameObject)BallListener.destoryGameobject[0]);  //销毁列表头对象
                BallListener.destoryGameobject.RemoveAt(0);                         //移除列表中的对象
                icount = 0;                                                         //重置计数器
            }
        }
    }
    public void Rota(int i) {                           //炮管旋转回调方法
        transform.Rotate(Vector3.forward, i * 5);
    }
    private void addCollider(ref Cloth c, SphereCollider sc) {
        ClothSphereColliderPair[] cscp = new ClothSphereColliderPair[c.sphereColliders.Length + 1]; //重新声明碰撞器数组
        for (int i = 0; i < c.sphereColliders.Length; i++) {
            cscp[i] = c.sphereColliders[i];                             //初始化碰撞器数组
        }
        cscp[cscp.Length - 1] = new ClothSphereColliderPair(sc);        //添加碰撞器
        BallListener.clothColliders.Add(cscp[cscp.Length - 1]);         //储存碰撞器至列表
        c.sphereColliders = cscp;                                       //设置碰撞列表
    }
    private void InitUI() {                                             //UI按钮屏幕自适应方法
        Vector2 editScreen = new Vector2(866, 477);
        Transform canvas = GameObject.Find("Canvas").transform;         //在Canvas下的对象将进行位置和大小的调整
        Vector2 scaleExchange = new Vector2(Screen.width / editScreen.x, Screen.height / editScreen.y);
        for (int i = 0; i < canvas.childCount; i++) {
            RectTransform canvasChildRT = canvas.GetChild(i).GetComponent<RectTransform>();
            canvasChildRT.position = new Vector3(scaleExchange.x * canvasChildRT.position.x,    //调整其位置
                                                 scaleExchange.y * canvasChildRT.position.y, 0);
            canvasChildRT.sizeDelta = new Vector3(scaleExchange.x * canvasChildRT.sizeDelta.x,    //调整其大小
                                                   scaleExchange.y * canvasChildRT.sizeDelta.y, 1);
        }
    }
}
