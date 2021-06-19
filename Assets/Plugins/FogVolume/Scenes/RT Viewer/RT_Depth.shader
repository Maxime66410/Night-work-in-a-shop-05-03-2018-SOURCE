Shader "Fog Volume/RT viewers/RT_Depth"
{
	Properties{
		[Toggle(RightEye)] _RightEye ("Right Eye?", Float) = 0	

		[hideininspector]_MainTex("Base", 2D) = "" {}
		_Intensity("Intensity", Range(1, 20)) = 1

	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma multi_compile _ _FOG_LOWRES_RENDERER 	
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ RightEye

			#include "UnityCG.cginc"
			float _Intensity;
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
			
				float4 vertex : SV_POSITION;
			};

			sampler2D RT_Depth, _MainTex;
			sampler2D RT_DepthR;
			float4 RT_Depth_ST, _MainTex_TexelSize, _MainTex_ST;
			sampler2D   _CameraDepthTexture;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture

				float Depth = 0;
				#ifdef RightEye
				 Depth = DecodeFloatRG(tex2D(RT_DepthR,  i.uv).zw);
				#else
				 Depth = DecodeFloatRG(tex2D(RT_Depth,  i.uv).zw);
				#endif

			//if(Depth==0)
			//Depth=1;
			
			return Depth * _Intensity;

			}
			ENDCG
		}
	}
}
