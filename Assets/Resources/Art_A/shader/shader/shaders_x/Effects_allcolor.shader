// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.02 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.02;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:2,bsrc:0,bdst:0,culm:2,dpts:2,wrdp:False,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:3,fgcr:0.1280277,fgcg:0.1953466,fgcb:0.2352941,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:7831,x:33031,y:32417,varname:node_7831,prsc:2|emission-7409-OUT;n:type:ShaderForge.SFN_Tex2d,id:1564,x:32364,y:31994,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_4951,prsc:2,tex:bf593ccd8f8084345ace42ae0cc2acce,ntxv:2,isnm:False|UVIN-4904-OUT;n:type:ShaderForge.SFN_Tex2d,id:7020,x:31839,y:32708,ptovrint:False,ptlb:Clip,ptin:_Clip,varname:node_7020,prsc:2,tex:5a2a4c3ee27954917a948e9ab129ef8d,ntxv:0,isnm:False|UVIN-4904-OUT;n:type:ShaderForge.SFN_Slider,id:7260,x:31731,y:32905,ptovrint:False,ptlb:clip,ptin:_clip,varname:node_7260,prsc:2,min:-0.2,cur:1.1,max:1.1;n:type:ShaderForge.SFN_Step,id:5763,x:32225,y:32614,varname:node_5763,prsc:2|A-7020-R,B-7260-OUT;n:type:ShaderForge.SFN_Blend,id:6792,x:32601,y:32327,varname:node_6792,prsc:2,blmd:0,clmp:True|SRC-6881-OUT,DST-5763-OUT;n:type:ShaderForge.SFN_Slider,id:6942,x:31446,y:31829,ptovrint:False,ptlb:V_animator,ptin:_V_animator,varname:node_6942,prsc:2,min:-1,cur:2,max:2;n:type:ShaderForge.SFN_Panner,id:5883,x:31822,y:31689,varname:node_5883,prsc:2,spu:0,spv:1|DIST-6942-OUT;n:type:ShaderForge.SFN_Multiply,id:4904,x:32163,y:32081,varname:node_4904,prsc:2|A-2983-OUT,B-6652-OUT;n:type:ShaderForge.SFN_Slider,id:6652,x:31554,y:32109,ptovrint:False,ptlb:UV,ptin:_UV,varname:node_6652,prsc:2,min:0,cur:0.4908168,max:1;n:type:ShaderForge.SFN_Color,id:2772,x:32444,y:32645,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_2772,prsc:2,glob:False,c1:0,c2:0.751724,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:3963,x:32758,y:32496,varname:node_3963,prsc:2|A-6792-OUT,B-2772-RGB;n:type:ShaderForge.SFN_ComponentMask,id:106,x:32665,y:32705,varname:node_106,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-2434-RGB;n:type:ShaderForge.SFN_Tex2d,id:2434,x:32382,y:32901,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_2434,prsc:2,tex:d24ee93a8253840a8a315d7ca89ba9ac,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7409,x:32840,y:32650,varname:node_7409,prsc:2|A-3963-OUT,B-106-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:6881,x:32308,y:32335,varname:node_6881,prsc:2|IN-1564-RGB,IMIN-1800-OUT,IMAX-741-OUT,OMIN-8002-OUT,OMAX-1973-OUT;n:type:ShaderForge.SFN_Vector1,id:8002,x:31890,y:32434,varname:node_8002,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1973,x:32066,y:32482,varname:node_1973,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:741,x:31830,y:32363,ptovrint:False,ptlb:Strength,ptin:_Strength,varname:node_741,prsc:2,min:0,cur:0.5741937,max:1;n:type:ShaderForge.SFN_Slider,id:1800,x:31830,y:32285,ptovrint:False,ptlb:Strength_Small,ptin:_Strength_Small,varname:node_1800,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:609,x:31564,y:31968,ptovrint:False,ptlb:U_animator,ptin:_U_animator,varname:node_609,prsc:2,min:-1,cur:-1,max:5;n:type:ShaderForge.SFN_Panner,id:9327,x:31931,y:31931,varname:node_9327,prsc:2,spu:1,spv:0|DIST-609-OUT;n:type:ShaderForge.SFN_Add,id:2983,x:32163,y:31848,varname:node_2983,prsc:2|A-5883-UVOUT,B-9327-UVOUT;proporder:7020-7260-6942-1564-6652-2772-2434-741-1800-609;pass:END;sub:END;*/

Shader "Shader Forge/Effects_allcolor" {
    Properties {
        _Clip ("Clip", 2D) = "white" {}
        _clip ("clip", Range(-0.2, 1.1)) = 1.1
        _V_animator ("V_animator", Range(-1, 2)) = 2
        _Texture ("Texture", 2D) = "black" {}
        _UV ("UV", Range(0, 1)) = 0.4908168
        _Color ("Color", Color) = (0,0.751724,1,1)
        _Mask ("Mask", 2D) = "white" {}
        _Strength ("Strength", Range(0, 1)) = 0.5741937
        _Strength_Small ("Strength_Small", Range(0, 1)) = 0
        _U_animator ("U_animator", Range(-1, 5)) = -1
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            Fog {Mode Off}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            //#define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _Clip; uniform float4 _Clip_ST;
            uniform float _clip;
            uniform float _V_animator;
            uniform float _UV;
            uniform float4 _Color;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _Strength;
            uniform float _Strength_Small;
            uniform float _U_animator;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float2 node_4904 = (((i.uv0+_V_animator*float2(0,1))+(i.uv0+_U_animator*float2(1,0)))*_UV);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_4904, _Texture));
                float node_8002 = 0.0;
                float4 _Clip_var = tex2D(_Clip,TRANSFORM_TEX(node_4904, _Clip));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 emissive = ((saturate(min((node_8002 + ( (_Texture_var.rgb - _Strength_Small) * (1.0 - node_8002) ) / (_Strength - _Strength_Small)),step(_Clip_var.r,_clip)))*_Color.rgb)*_Mask_var.rgb.r);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
