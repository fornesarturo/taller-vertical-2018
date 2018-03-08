Shader "Sahder/Night"
{
	Properties
	{
		_MainTex("Main Texture", 2D) = "white" {}
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			///content of screen in a texture
		//names must be the same as the script
			sampler2D _MainTex;
			float4 Color;
		
			sampler2D VignetteTex;
			float Darkness;

			struct appdata
			{
				float4 position: POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{	
				float4 clipPosition: SV_POSITION;
				//float2 vertex:SV_POSITION;
				float2 uv : TEXCOORD0;
			};
		
			v2f vert (appdata v)
			{
				v2f o;
				//ModelViewProjection Matrix
				o.clipPosition = UnityObjectToClipPos(v.position);
				//o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			float4 frag (v2f i) : COLOR
			{
				return tex2D(_MainTex,i.uv) *(1.0 - tex2D(VignetteTex, i.uv).a)*Color;
			}

			ENDCG
		}
	}
}
