Shader "Custom/ToDoSurfaceShader_NotPBR" 
{
	Properties 
	{				
		_MainTex ("Albedo", 2D) = "white" {}		
	}
	
	SubShader 
	{		
		Cull off //two sided rendering
		CGPROGRAM		
		#pragma surface surf Lambert addshadow //forma de la sombra

		sampler2D _MainTex;
		
		struct Input 
		{
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{	
			fixed4 texelColor = tex2D(_MainTex, IN.uv_MainTex);
			if (texelColor.a<.01)
				discard; //dont render
			o.Albedo = texelColor.rgb;
		}
		ENDCG
	}
	
	FallBack "Diffuse"
}
