// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

// ShaderLab files support:
// * Completion
// * Live templates, including custom scopes to create your own
//   Create properties (color, float, int, tex*, cub*, vec)
//   Main shader block (shader)
//   SubShader block (surf, vfshader)
//   Pass block (vfpass)
//   Blend operations (blend*)
// * Code folding
// * Breadcrumbs
// * Extend selection
// * Formatting (with ShaderLab CodeStyle page)
//
// Plus features in HLSL blocks:
// * Language analysis + quick fixes
// * Ctrl+Click navigation to include files, macros, etc.
// * Support for variant keywords

Shader "Custom/VariantKeywordsExampleShader" {
    Properties {
        // TODO: Fix colours
        _Color ("Color", Color) = (0.3, 0.05, 0.6, 1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        
        // Live templates - color, float, int, tex*, cube*, vec
        _MyProperty("MyProperty", Float) = 1.2
        _NAME("NAME", Color) = (0.97, 0.66, 0.44, 1)
    }
    
    // Live template - surf
    
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200
        Cull [_Color]   // Dodgy shader code :) But example of using a property defined above. Go to definition, rename,
        Cull [_Color]   // Find Usages, etc.
        Cull [_MainTex]

        Pass
        {
            CGPROGRAM

            // CTRL+Click to navigate to the entry point functions
            #pragma vertex vert     
            #pragma fragment frag

            // Ctrl+Click navigation to includes, even those shipped with Unity
            #include "UnityCG.cginc"

            struct appdata22
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata22 v)
            {
                v2f o2222;
                o2222.vertex = UnityObjectToClipPos(v.vertex);
                return o2222;
            }

            half4 frag(v2f i) : SV_Target
            {
                return 1;
            }
            ENDCG
        }
        
        // Use live templates for blend operations - blendadditive, blendmultiplicative, etc.
        Blend One One
        Blend DstColor Zero


        CGPROGRAM

        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        // Define some shader keywords. These will be listed in the Variants widget in the editor breadcrumbs.
        // Note that they are styled differently to traditional preprocessor define symbols
        // We can also use alt+enter to enable one or more. They will be hihglighted in bold and underlined
        #pragma shader_feature _ BLUE RED GREEN

        sampler2D _MainTex;

        struct Input {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o) {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;

            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;

            // Traditional preprocessor symbol. Note the styling difference
            #if !UNITY_FIXED_IS_HALF
            fixed4 something = c;
            o.Alpha = something.a;
            #endif

            // Use alt+enter to enable/disable the keywords. Notice highlighting of the symbol changes, as does
            // highlighting and code insight features for each preprocessor branch
            #if BLUE
            o.Albedo = float4(0, 0, 1, 1);
            #elif GREEN
            o.Albedo = float4(0, 1, 0, 1);
            #elif RED
            o.Albedo = float4(1, 0, 0, 1);
            #else
            o.Albedo = c;
            #endif

            // This is an implicit keyword. Use the Variant widget in the breadcrumb bar to enable mobile or desktop
            #if SHADER_API_DESKTOP
            o.Metallic = _Metallic;
            #endif
        }
        ENDCG
    }

    // Code completion of shaders found in the project, packages and built in shaders
    // (You can see this shader in the list, although you wouldn't want to select it here)
    FallBack "Diffuse"
}

/*
// Nice conceptual model of what this means. If the RED keyword is enabled, the RED preprocessor symbol is defined, same
// with BLUE and GREEN. If none are enabled, then BLUE is enabled by default

#pragma shader_feature BLUE RED GREEN

#if enabled(RED)
#define RED 1
#elif enabled(BLUE)
#define BLUE 1
#elif enabled(GREEN)
#define GREEN 1
#else
#define BLUE 1 // first as default
#endif

// This doesn't have a default active keyword, due to the `_`
#pragma shader_feature _ BLUE RED GREEN
/*
