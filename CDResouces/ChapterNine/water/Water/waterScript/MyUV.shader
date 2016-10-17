Shader "Custom/MyUV" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_NormalMap ("NormalMap", 2D) = "white" {}
		_Aim1("Aim1",Vector)=(0,0,0,0)
		_Aim2("Aim2",Vector) = (1,0,0,0)
		_Aim3("Aim2",Vector) = (1,0,0,0)
		_Aim4("Aim2",Vector) = (1,0,0,0)

	}
	SubShader {
		Pass{
			CGPROGRAM
			#pragma vertex verf
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _NormalMap;
			float4 _Aim1;
			float4 _Aim2;
			float4 _Aim3;
			float4 _Aim4;
			float4 _MainTex_ST;

			struct v2f {
				float4 pos:SV_POSITION;
				float2 uv:TEXCOORD0;
			};
			v2f verf(appdata_base v)
			{
				v2f o;

				float dis1 = distance(v.vertex.xyz,_Aim1.xyz);
				float dis2 = distance(v.vertex.xyz,_Aim2.xyz);
				float dis3 = distance(v.vertex.xyz,_Aim3.xyz);
				float dis4 = distance(v.vertex.xyz,_Aim4.xyz);

				float H = sin(dis1*_Aim1.w+_Time.z)/10;
				H+=sin(dis2*_Aim2.w+_Time.z)/20;
				H+=sin(dis3*_Aim3.w+_Time.z)/15;
				H+=sin(dis4*_Aim4.w+_Time.z)/10;
				o.uv = TRANSFORM_TEX(v.texcoord,_MainTex);
				o.pos = mul(_Object2World,v.vertex);
				o.pos.y=H;
				o.pos= mul(_World2Object,o.pos);
				o.pos = mul(UNITY_MATRIX_MVP,o.pos);
				
				return o;
			}
			fixed4 frag(v2f_img i):COLOR
			{
				float4 texCol=tex2D(_MainTex,i.uv);	
				float4 packedNormal = tex2D(_NormalMap, i.uv);
				return texCol;
			}
			ENDCG
		}
	} 
	FallBack "Diffuse"
}