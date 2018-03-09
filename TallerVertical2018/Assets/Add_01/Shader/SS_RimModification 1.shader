Shader "Custom/NewSurfaceShader" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)

		_AlbedoTex("Albedo Texture", 2D) = "white" {}
		_MetallicTex("Metallic Range", Range(1.0,0.0)) = 0.5
		_SmoothTex("Smooth Range", Range(1.0,0.0)) = 0.5
		//_MetallicTex("Metallic Texture", 2D) = "white" {}
		//_SmoothTex("Smooth Texture", 2D) = "white" {}

		_RimPower("Power", Range(3.0,0.0)) = 0.5
		_RimColor("Color",  Color) = (1,0,0,1)

		//_EmissiveMap("Emissive Map", 2D) = "white" {}

	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _AlbedoTex;
		float _MetallicTex;
		float _SmoothTex;

		float _RimPower;
		float4 _RimColor;

		//float4 _PixelPosition;

		struct Input {
			float2 uv_AlbedoTex;
			float3 viewDir;//view direction
			float3 worldNormal;//view direction
			float3 worldPos;//world Position
			float3 worldRefl; INTERNAL_DATA
		};
	
		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		/*void vert(inout appdata_full v) {
			// _PixelPosition= tex2Dlod(_SandTex, v.vertex);
		}*/

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			//o.Albedo = c.rgb;

			//float _DistanceLerpFactor =saturate(dot(IN.worldPos, IN.viewDir))-_PixelPosition;
			//ESTO ES LO IMPORTANTE, LA DISTANCIA ENTRE LA CAMARA Y EL MESH
			
			o.Albedo = tex2D(_AlbedoTex, IN.uv_AlbedoTex).rgb;
			
			//o.Normal = UnpackNormal(tex2D(_NormalTex, IN.uv_AlbedoTex));
			//WorldReflectionVector(IN, o.Normal)
			// Metallic and smoothness come from slider variables
			//o.Metallic = _Metallic; Metallic was a half (determined by slider)
			o.Smoothness = _SmoothTex;

			o.Metallic = _MetallicTex;
			
			float NdotV = 1.0 - saturate(dot(IN.worldNormal, IN.viewDir));
			o.Emission = _RimColor*pow(NdotV, _RimPower);
			//smoothness is the alpha 
		}
		ENDCG
	}
	FallBack "Diffuse"
}
