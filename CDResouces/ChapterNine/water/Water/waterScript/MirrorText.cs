using UnityEngine;
using System.Collections;

public class MirrorText : MonoBehaviour {
    public RenderTexture refTex;
    public Matrix4x4 world2MirCam;
    public Matrix4x4 projM;//
    public Matrix4x4 cm;//镜像相机内的投影矩阵
    public Matrix4x4 correction;
    
    private Camera mirrorCam;
    private bool busy = false;
	void Start () {
        if (mirrorCam)
        {
            return;            
        }
        GameObject g = new GameObject("Mirror Camera");
         mirrorCam=g.AddComponent<Camera>();
         mirrorCam.enabled = false;

         refTex = new RenderTexture(1600,1200,16);//渲染纹理 16为深度位数
         refTex.hideFlags = HideFlags.DontSave;//设置图片的隐藏标示
         mirrorCam.targetTexture = refTex;

         GetComponent<Renderer>().material.SetTexture("_MainTex", refTex);

         correction = Matrix4x4.identity;//标准化矩阵
         correction.SetColumn(3, new Vector4(0.5f, 0.5f, 0.5f, 1f));
         correction.m00 = 0.5f;
         correction.m11 = 0.5f;
         correction.m22 = 0.5f;

	}
    void OnWillRenderObject()
    {
        if (busy)
        {
            return;
        }
        else
        {
            busy = true;
        }//防止串线

        Camera cam = Camera.main;

        //Debug.Log(cam.gameObject.name+" "+cam.transform.position);
        mirrorCam.CopyFrom(cam);//将设置拷贝到mirrorcam

        mirrorCam.transform.parent = transform;//将mirrorCamera设置为镜子的子物体
        Camera.main.transform.parent = transform;

        Vector3 mirrpos = mirrorCam.transform.localPosition;
        mirrpos.y *= -1;//对位置做镜像
        mirrorCam.transform.localPosition = mirrpos;

        Vector3 rt = Camera.main.transform.localEulerAngles;
        Camera.main.transform.parent = null;//设置主摄像机的父对象为空
        mirrorCam.transform.localEulerAngles = new Vector3(-rt.x,rt.y,-rt.z);//镜像主摄像机的角度
        //镜像完毕
        float d = Vector3.Dot(transform.up, Camera.main.transform.position - transform.position) + 0.05f;
        mirrorCam.nearClipPlane = d;//摄像机的剪裁平面

        mirrorCam.targetTexture = refTex;//设目标纹理
        mirrorCam.Render();//渲染
        Proj();//矩阵转换
        GetComponent<Renderer>().material.SetMatrix("_ProjMat", cm);

        busy = false;
    }
    void Proj()
    {
        world2MirCam = mirrorCam.transform.worldToLocalMatrix;//将世界矩阵转为自身矩阵
        projM = mirrorCam.projectionMatrix;//得到摄像机的投影矩阵
        //Debug.Log(projM.m32);
        projM.m32 = 1;//第32个数字  翻转
        cm = correction * projM * world2MirCam;
    }

	void Update () {
        GetComponent<Renderer>().material.SetTexture("_MainTex", refTex);
	}
}

