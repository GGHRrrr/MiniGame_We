Shader "PostProcess/PostTextureShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Alpha ("Í¸Ã÷¶È",float) = 1
        _Canvastex ("¸²¸ÇÌùÍ¼",2D) = "white" {}
    }
    SubShader
    {

        Pass
        {
            ZTest Always
            Cull off
            Zwrite off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _Canvastex;
            float4 _Canvastex_ST;
            float _Alpha;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float4 var_MainTex = tex2D(_MainTex,i.uv);
                float4 var_CanvasTex = tex2D(_Canvastex,i.uv);
                float3 color =max(0, 1-(1-var_MainTex.rgb)/max(0,var_CanvasTex));
                float3 finalcolor = _Alpha * color + (1-_Alpha) * var_MainTex;
                return float4(finalcolor,1);
            }
            ENDCG
        }
    }
}
