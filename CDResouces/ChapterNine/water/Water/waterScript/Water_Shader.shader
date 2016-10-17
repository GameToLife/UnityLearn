Shader "Custom/Water_Shader" {
	Properties {
		_MainTint("Diffuse Tint",Color) = (1,1,1,0)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_BackTint("Back Tint",Color) = (1,1,1,0)
		_BackTex("Background",2D)="white" {}
		_SpecColor("Specular Color",Color)=(1,1,1,1)
		_SpecPower("Specular Power",Range(0.5,100))=3
		_NormalTex("Normal Map",2D)="bump"{}
		_TransVal("Transparecy Value",Range(0,1))=0.5
		
		_PerturbationAmt  ("Perturbation Amt", range (0,1)) = 1
	}
	SubShader {
		
			Tags {"Queue"="Transparent-20" "RenderType"="Opaque" }//因为是透明的  所以要确保别的比这个先渲染
		
			CGPROGRAM
			
			#pragma surface surf CustomBlinnPhong vertex:vert alpha
			#pragma target 3.0
			#include "UnityCG.cginc"
			
			sampler2D _MainTex;			//主纹理
			sampler2D _NormalTex;		//法线图
			sampler2D _BackTex;			//背景色
			float _SpecPower;			//高光强度
			float4 _MainTint;			//主颜色
			float4 _BackTint;			//背景色
			float _TransVal;			//透明度
			float4x4 _ProjMat;			//摄像机投影矩阵
			
			float _PerturbationAmt;
			struct Input {
				float2 uv_MainTex;
				float2 uv_NormalTex;
				//float2 uv_BackTex;
				float4 pos;
				float4 texc;
				INTERNAL_DATA
			};

			inline fixed4 LightingCustomBlinnPhong(SurfaceOutput s,fixed3 lightDir,half3 viewDir,fixed atten)
			{
				float3 halfVector = normalize(lightDir+viewDir);
				float diff = max(0,dot(s.Normal,lightDir));
				float nh = max(0,dot(s.Normal,halfVector));
				float spec= pow(nh,_SpecPower)*_SpecColor;
				float4 c;
				c.rgb= (s.Albedo*_LightColor0.rgb*diff)+(_LightColor0.rgb*_SpecColor.rgb*spec)*(atten*2);
				c.a=s.Alpha;
				return c;
			}

			void vert (inout appdata_full v,out Input o) 
			{
				UNITY_INITIALIZE_OUTPUT(Input,o);
				o.pos=v.vertex;
			}

			void surf (Input IN, inout SurfaceOutput o) {
				float4x4 proj=mul(_ProjMat,_Object2World);
				
				IN.texc=mul(proj,IN.pos);
				
				float4 c_Back = tex2D(_BackTex,IN.uv_MainTex);//背景色采样
				
				
				float3 normalMap=UnpackNormal(tex2D(_NormalTex,IN.uv_NormalTex));// 采样法线图
				
				half2 offset=IN.texc.rg/IN.texc.w;//原纹理坐标
				offset.x=offset.x+_PerturbationAmt*offset.x*normalMap.x;
				offset.y=offset.y+_PerturbationAmt*offset.y*normalMap.y;
				float4 c_Main = tex2D(_MainTex,offset)*_MainTint;//反射纹理采样
				float3 finalcolor=lerp(c_Back,c_Main,0.7).rgb*_BackTint;//最终颜色
				
				
				o.Normal=normalize(normalMap.rgb+o.Normal.rgb);
				o.Specular= _SpecPower;
				o.Gloss=1.0;
				o.Albedo=finalcolor;
				o.Alpha=(c_Main.a*0.5+0.5)*_TransVal;
			}
			ENDCG
		
	} 
	FallBack "Diffuse"
}
