 
Shader "Custom/PostShader" {
Properties 
	{
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Color ("Main Color", Color) = (1,0,0,1.5)
		_BlurAmount ("Blur Amount", Range(0,1)) = 0.01
	}
	
	Category 
	{
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		ZWrite Off
		//Alphatest Greater 0
		Blend SrcAlpha OneMinusSrcAlpha 
		Fog { Color(0,0,0,0) }
		Lighting Off
		Cull Off //we can turn backface culling off because we know nothing will be facing backwards
 
		BindChannels 
		{
			Bind "Vertex", vertex
			Bind "texcoord", texcoord 
			Bind "Color", color 
		}
 
		SubShader   
		{
			Pass 
			{
				//SetTexture [_MainTex] 
				//{
				//	Combine texture * primary
				//}
				
				
				
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
#pragma profileoption NumTemps=64
float4 _Color;
sampler2D _MainTex;
float _BlurAmount;
 
struct v2f {
    float4  pos : SV_POSITION;
    float2  uv : TEXCOORD0;
};
 
float4 _MainTex_ST;
 
v2f vert (appdata_base v)
{
    v2f o;
    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
    return o;
}
 
half4 frag (v2f i) : COLOR
{
 
    //half4 texcol = tex2D (_MainTex, i.uv);
    //return texcol * _Color;
    
    half4 texcol = half4(0.0,0.0,0.0,0.0);
    float remaining=1.0f;
    float coef=1.0;
    float fI=0;
    for (int j = 0; j < 3; j++) {
    	fI++;
    	coef*=0.32;
    	texcol += tex2D(_MainTex, float2(i.uv.x, i.uv.y - fI * _BlurAmount)) * coef;
    	texcol += tex2D(_MainTex, float2(i.uv.x - fI * _BlurAmount, i.uv.y)) * coef;
    	texcol += tex2D(_MainTex, float2(i.uv.x + fI * _BlurAmount, i.uv.y)) * coef;
    	texcol += tex2D(_MainTex, float2(i.uv.x, i.uv.y + fI * _BlurAmount)) * coef;
    	
    	remaining-=4*coef;
    }
    texcol += tex2D(_MainTex, float2(i.uv.x, i.uv.y)) * remaining;
 
    return texcol;
}
ENDCG				
				
			}

			Pass 
			{
				//SetTexture [_MainTex] 
				//{
				//	Combine texture * primary
				//}
				
				
				
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
#pragma profileoption NumTemps=64
float4 _Color;
sampler2D _MainTex;
 
struct v2f {
    float4  pos : SV_POSITION;
    float2  uv : TEXCOORD0;
};
 
float4 _MainTex_ST;
 
v2f vert (appdata_base v)
{
    v2f o;
    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
    return o;
}
 
half4 frag (v2f i) : COLOR
{
 
    //half4 texcol = tex2D (_MainTex, i.uv);
    //return texcol * _Color;
   float2 p = float2(i.pos.x - 0.5 * _ScreenParams.x, i.pos.y - 0.5 * _ScreenParams.y) / _ScreenParams.y;
   float rad = length(p);
   float angle = atan2(p.y,p.x);
   float ma = fmod(angle, (2.0 * 3.141592658) / 200.0);
   ma = abs(ma - 3.141592658 / 200.0);
   float x = cos(ma) * rad;
   float y = sin(ma) * rad;
   float time = _Time;
   return tex2D(_MainTex,float2(x-time,y-time));
}
ENDCG				
				
			}



		} 
	}
Fallback off

}