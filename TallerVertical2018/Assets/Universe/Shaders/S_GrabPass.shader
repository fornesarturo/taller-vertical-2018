Shader "Week9/GrabPass"
{
	Properties
	{
		_Color("Color", Color) = (1.0, 0.0, 0.0, 0.0)
		_NormalMap("Normal Map", 2D) = "bump" {}
		_Distortion("Distortion Factor", Range(0.0, 10.0)) = 5.0

	}
	SubShader
	{
		Tags { "Queue"="Transparent" }

		// First pass
		// Unity "takes a screenshot of what is covered by the mesh".
		GrabPass {}
		
		// Second pass
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			fixed4 _Color;
			sampler2D _NormalMap;
			fixed _Distortion;
			sampler2D _GrabTexture;

			struct appdata //antes appdata
			{
				float4 position: POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 clipPosition: SV_POSITION;
				float2 uv : TEXCOORD0;
				
				float4 uv_GrabPass : TEXCOORD1;
			};
			
			v2f vert (appdata v) //inout appdata_full v
			{
				v2f o;
				o.clipPosition = UnityObjectToClipPos(v.position);
				o.uv = v.uv;
				// To do...
				// UnityObjectToClipPos(vertex in object space)  => and returns vertex position in clip space
				o.uv_GrabPass= ComputeGrabScreenPos(o.clipPosition);
				// Use the function ComputeGrabScreenPos to compute the uv of the grab texture
				// The parameter of this method is the vertex in CLIP SPACE.				
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{		
				//return tex2D(_MainTex,i.uv)*Darkness;
				half4 normalDistortion = half4(UnpackNormal(tex2D(_NormalMap,i.uv+float2(_Time.x,0.0))),0.0);
				// 1.
				// Get the vector from the normal map and save it in a half4 variable. => the w component of a vector = 0.0
				// Call it normalDistortion
				// Use the default uvs to read the texture.
				i.uv_GrabPass += (normalDistortion*_Distortion);
				// 2.
				// Disturb the uvs of the Grab texture by adding an offset => normalDistortion & the slide value
				
				return tex2Dproj(_GrabTexture, i.uv_GrabPass)*_Color;
				// Read and return the _GrabTexture texel color.
				// Read it with the function: tex2Dproj(sampler2D NameOfTheTexture, half4 uvs) as we project the texture on the mesh.
			}
			
			ENDCG
		}
	}
}
