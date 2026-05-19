Shader "Revealing Under Light (URP)"
{
    Properties
    {
        
        _BaseColor("Color", Color) = (1,1,1,1)
        _BaseMap("Albedo (RGB)", 2D) = "white" {}
        _Smoothness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
        _LightDirection("Light Direction", Vector) = (0,0,1,0)
        _LightPosition("Light Position", Vector) = (0,0,0,0)
        _LightAngle("Light Angle", Range(0,180)) = 45
        _StrengthScalor("Strength", Float) = 50
    }

    SubShader
    {
        Cull off

        Tags 
        { 
            "RenderType" = "Transparent" 
            "Queue" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
        }

        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {

            ColorMaterial AmbientAndDiffuse
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 positionWS : TEXCOORD1;
            };

            sampler2D _BaseMap;
            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
                float4 _BaseColor;
                float _Smoothness;
                float _Metallic;
                float3 _LightPosition;
                float3 _LightDirection;
                float _LightAngle;
                float _StrengthScalor;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);
                OUT.positionWS = TransformObjectToWorld(IN.positionOS.xyz);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                // Calculate light direction and strength
                float3 lightDir = normalize(_LightPosition - IN.positionWS);
                float scale = dot(lightDir, normalize(_LightDirection));
                float strength = scale - cos(_LightAngle * (3.14 / 360.0));
                strength = saturate(strength * _StrengthScalor);

                // Sample texture and apply color
                half4 color = tex2D(_BaseMap, IN.uv) * _BaseColor;
                
                // Apply alpha based on strength
                color.a *= strength;
                return color;
            }
            ENDHLSL
        }
    }
    FallBack "Universal Render Pipeline/Lit"
}