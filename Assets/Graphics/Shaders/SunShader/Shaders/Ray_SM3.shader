﻿//
// SunShader 1.0
//
// Panteleymonov Aleksandr 2016
//
// foxes@bk.ru
// manil@panteleymonov.ru
//

Shader "Space/Star/Ray"
{
	Properties
	{
		_Radius("Radius", Float) = 0.5
		_RayString("Ray String", Range(0.02,10.0)) = 1.0
		_RayLight("Ray Light", Color) = (1,0.95,1.0,1)
		_Ray("Ray End", Color) = (1,0.6,0.1,1)
		_Rays("Rays", Range(1.0,10.0)) = 2.0
		_RayRing("Ray Ring", Range(1.0,10.0)) = 1.0
		_RayGlow("Ray Glow", Range(1.0,10.0)) = 2.0
		_Glow("Glow", Range(1.0,100.0)) = 4.0
		_Zoom("Zoom", Float) = 1.0
		_SpeedRay("Speed Ray", Range(0.0,10)) = 5.0
		_SpeedRing("Speed Ring", Range(0.0,20)) = 2.0
		//_MainTex("Random Texture", 2D) = "white"
	}
		SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		//Tags { "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
			//Tags{ "Queue" = "Transparent" }
			Blend One OneMinusSrcAlpha
			//ZWrite Off
			//Cull Front
			//ColorMask 0
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			//#pragma multi_compile_fog
			#pragma target 3.0
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
			#if UNITY_5_0
				UNITY_FOG_COORDS(1)
			#endif
				float4 vertex : SV_POSITION;
			//#if SHADER_API_D3D11 
				float3 uv1 : TEXCOORD1;
			//#endif
			};

			sampler2D _MainTex;
			//float4 _MainTex_ST;
			float _Radius;
			float _RayString;
			fixed4 _Ray;
			fixed4 _RayLight;
			float _Rays;
			float _RayRing;
			float _RayGlow;
			float _Zoom;
			float _SpeedRay;
			float _SpeedRing;
			float _Glow;
			float _Seed;
			float4 posGlob; // center position
			
			v2f vert (appdata v)
			{
				v2f o;
				//o.uv1 = (float3)v.vertex;
				//o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				
				posGlob = float4(UNITY_MATRIX_MV[0].w, UNITY_MATRIX_MV[1].w, UNITY_MATRIX_MV[2].w,0);
				float3x3 r=transpose((float3x3)UNITY_MATRIX_MV);
				float3x3 m;
				m[2]=normalize(mul(r,(float3)posGlob));
				m[1]=normalize(cross(m[2],float3(0.0, 1.0, 0.0)));
				m[0]=normalize(cross(m[1],m[2]));
				o.uv1 = mul(transpose(m), (float3)v.vertex);
            	o.vertex = mul(UNITY_MATRIX_MVP, float4(o.uv1, 1.0));
            	
				#if UNITY_5_0
				UNITY_TRANSFER_FOG(o,o.vertex);
				#endif
				return o;
			}

			// animated noise
			fixed4 hash4(fixed4 n) { return frac(sin(n)*(fixed)753.5453123); }

			// mix noise for alive animation
			fixed noise4d(fixed4 x)
			{
				fixed4 n3 = fixed4(0,0.5,0,0.5);
				fixed4 p1 = floor(x.xxww+n3);
				fixed4 p2 = floor(x.yyzz+n3);
				p1.xy = p1.xy + floor(x.yy+n3.xy)*157.0 + floor(x.zz+n3.xy)*113.0;
				p1 = p1.xxyy + frac((p1.zzww + fixed4(0, 1, 0, 1))*0.00390625)*fixed4(164352.0, 164352.0, -164352.0, -164352.0);
				//p1 = p1.xxyy+frac((p1.zzww + fixed4(0,1,0,1))*0.00390625)*164352.0;
				fixed4 f1 = frac(x.xxyy+n3);
				fixed4 f2 = frac(x.zzww+n3);
				fixed4 n1 = fixed4(0,1.0,157.0,158.0);
				fixed4 n2 = fixed4(113.0,114.0,270.0,271.0);
				fixed4 vs1 = lerp(hash4(p1), hash4(n1.yyyy+p1), f1.xxyy);
				fixed4 vs2 = lerp(hash4(n1.zzzz+p1), hash4(n1.wwww+p1), f1.xxyy);
				vs1 = lerp(vs1, vs2, f1.zzww);
				vs2 = lerp(hash4(n2.xxxx+p1), hash4(n2.yyyy+p1), f1.xxyy);
				fixed4 vs3 = lerp(hash4(n2.zzzz+p1), hash4(n2.wwww+p1), f1.xxyy);
				vs2 = lerp(vs2, vs3, f1.zzww);
				vs1 = lerp(vs1, vs2, f2.xxyy);
				fixed2 vs=lerp(vs1.xz, vs1.yw, f2.zw);
				return (vs.x+vs.y)*0.5;
			}
			
			float RayProj;
			float sqRadius; // sphere radius
			float fragTime;
			float sphere; // sphere distance

			fixed4 frag (v2f i) : SV_Target
			{
				float invz =1/_Zoom;
				_Radius*=invz;
				fragTime=_Time.x*10.0;
				posGlob = float4(UNITY_MATRIX_MV[0].w, UNITY_MATRIX_MV[1].w, UNITY_MATRIX_MV[2].w,0);
				float3x3 m = (float3x3)UNITY_MATRIX_MV;
				float3 ray = normalize(mul(m, i.uv1) + posGlob.xyz);
				m = transpose((float3x3)UNITY_MATRIX_V);

				RayProj = dot(ray, (float3)posGlob);
				sphere = dot((float3)posGlob, (float3)posGlob) - RayProj*RayProj;
				sqRadius = _Radius*_Radius;
				float sqDist=dot((float3)posGlob, (float3)posGlob);
				
				float3 pr = ray*abs(RayProj) - (float3)posGlob;

				fixed4 col = fixed4(0,0,0,0);

				fixed c = length(pr)*_Zoom;
				pr = normalize(mul(m, pr));
				fixed s = max(0.0, (1.0 - abs(_Radius*_Zoom - c) / _RayString));
				fixed nd = noise4d(float4(pr, -fragTime*_SpeedRing + c))*2.0;
				nd = pow(nd, 2.0);
				fixed dr=1.0;
				if (sphere < sqRadius) dr = sphere / sqRadius;
				pr*=10.0;
				fixed n = noise4d(float4(pr+ _Seed, -fragTime*_SpeedRing + c))*dr;
				pr*=5.0;
				fixed ns = noise4d(float4(pr+ _Seed, -fragTime*_SpeedRay + c*2.0))*2.0*dr;
				n = pow(n, _Rays)*pow(nd,_RayRing)*ns;
				fixed s3 = pow(s, _Glow) + pow(s, _RayGlow)*n;

				//float s3 = ringRayNoise(ray, (float3)posGlob, _Radius, _RayString, m, fragTime);
				//if (sphere < sqRadius) col.w = 1.0-s3*dr;
				if (sqDist>sqRadius)
					col.xyz = col.xyz+lerp((fixed3)_Ray, (fixed3)_RayLight, s3*s3*s3)*s3; //pow(s3, 3.0)
				
				col = clamp(col, 0, 1);

#if UNITY_5_0
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
#endif
				return col;
			}
			ENDCG
		}
	}
}
