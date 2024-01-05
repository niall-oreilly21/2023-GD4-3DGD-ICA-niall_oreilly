Shader "FREE Food Pack/Food" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _FresnelSize ("FresnelSize", Range(0.5, 5)) = 0.6153846
        _FresnelIntensity ("FresnelIntensity", Float) = 1
        _FresnelColor ("FresnelColor", Color) = (0.5, 0.5, 0.5, 1)
        _push ("push", Range(0, 0.01)) = 0
        _Speed ("Speed", Float) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _FresnelSize;
            uniform float _FresnelIntensity;
            uniform float4 _FresnelColor;
            uniform float _push;
            uniform float _Speed;
            
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            
            VertexOutput vert(VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_9990 = _Time + _TimeEditor;
                v.vertex.xyz += ((_push * (sin((node_9990.g * _Speed)) * 0.5 + 0.5)) * v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }
            
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                
                // Lighting:
                // Emissive:
                float4 _MainTex_var = tex2D(_MainTex, TRANSFORM_TEX(i.uv0, _MainTex));
                float3 emissive = ((_FresnelColor.rgb * pow(1.0 - max(0, dot(normalDirection, viewDirection)), _FresnelSize) * _FresnelIntensity) + _MainTex_var.rgb);
                float3 finalColor = emissive;
                
                return fixed4(finalColor, 1);
            }
            ENDCG
        }
        
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            
            uniform float4 _TimeEditor;
            uniform float _push;
            uniform float _Speed;
            
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float3 normalDir : TEXCOORD1;
            };
            
            VertexOutput vert(VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_9990 = _Time + _TimeEditor;
                v.vertex.xyz += ((_push * (sin((node_9990.g * _Speed)) * 0.5 + 0.5)) * v.normal);
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
