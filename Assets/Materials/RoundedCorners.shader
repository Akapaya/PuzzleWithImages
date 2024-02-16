Shader"Custom/RoundedCorners"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Radius ("Radius", Range(0, 0.5)) = 0.1
    }
 
    SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
Blend SrcAlpha
OneMinusSrcAlpha
        ZWrite
Off
        CullOff
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
#include "UnityCG.cginc"
 
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
 
sampler2D _MainTex;
float _Radius;
 
v2f vert(appdata v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = v.uv;
    return o;
}
 
fixed4 frag(v2f i) : SV_Target
{
    float2 center = float2(0.5, 0.5);
    float dist = distance(i.uv, center);
    float alpha = smoothstep(_Radius - 0.01, _Radius, dist);
    return tex2D(_MainTex, i.uv) * alpha;
}
            ENDCG
        }
    }
}
