using UnityEngine;
using System.Collections;

public class Water_wave : MonoBehaviour {
    private Vector3[] vertices;
    private float mytime;
    private Vector3 localdtoworld;
    //public float waveLength = 0.001f;//波长
    public float waveFrequency1 = 0.3f;//波频
    public float waveFrequency2 = 0.5f;//波频
    public float waveFrequency3 = 0.9f;//波频
    public float waveFrequency4 = 1.5f;//波频
    private Vector3 v_zero = Vector3.zero;
    public float Speed = 1;
    private  int index1= 760;
    private int index2 = 900;
    private int index3 = 12000;
    private Vector2 uv_offset = Vector2.zero;
    private Vector2 uv_direction = new Vector2(0.5f,0.5f);
	// Use this for initialization
	void Start () {
        vertices = GetComponent<MeshFilter>().mesh.vertices;//获取网格顶点坐标数组值
        //Debug.Log(Mathf.Sin(1.56f));
        //Debug.Log(Mathf.Sin(1 / 2.0f * Mathf.PI));

	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Mathf.Sin(mytime)+"   "+mytime);
        

        mytime += Time.deltaTime*Speed;
        for (int i = 0; i < vertices.Length;i++ )
        {
            //localdtoworld = transform.TransformPoint(vertices[i]);
            vertices[i] = new Vector3(vertices[i].x, FindHight(i), vertices[i].z);

        }
        //vertices[index1] = new Vector3(vertices[index1].x,FindHight(),vertices[index1].z);
        GetComponent<MeshFilter>().mesh.vertices=vertices;
        uv_offset += (uv_direction * Time.deltaTime*0.1f);

        this.GetComponent<Renderer>().material.SetTextureOffset("_NormalTex", uv_offset);
		//this.renderer.material.SetTextureOffset("_BackTex", uv_offset);

        GetComponent<MeshFilter>().mesh.RecalculateNormals();//重新计算法线
        //Debug.Log(GetComponent<MeshFilter>().mesh.normals[index1]);
	}
    float FindHight()
    {
        float H = Mathf.Sin(mytime);
        return H;
    }
    float FindHight(int i)
    {
        float H = 0;
        float distance1= Vector2.Distance(new Vector2(vertices[i].x,vertices[i].z),v_zero);//获取点到中心点的距离
        //float distance1 = (vertices[i].x - v_zero.x);
        float distance2 = Vector2.Distance(new Vector2(vertices[i].x, vertices[i].z), new Vector2(vertices[index1].x,vertices[index1].z));
        float distance3 = Vector2.Distance(new Vector2(vertices[i].x, vertices[i].z), new Vector2(vertices[index2].x, vertices[index2].z));
        float distance4 = Vector2.Distance(new Vector2(vertices[i].x, vertices[i].z), new Vector2(vertices[index3].x, vertices[index3].z));

        H  = Mathf.Sin((distance1) * waveFrequency1 * Mathf.PI + mytime) / 30;
        H += Mathf.Sin((distance2) * waveFrequency2 * Mathf.PI + mytime) / 25;
        H += Mathf.Sin((distance3) * waveFrequency3 * Mathf.PI + mytime) / 35;
        H += Mathf.Sin((distance4) * waveFrequency4 * Mathf.PI + mytime) / 40;
        return H;
    }
}
