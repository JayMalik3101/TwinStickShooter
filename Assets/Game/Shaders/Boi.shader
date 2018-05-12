Shader "PBR Master"
{
	Properties
	{
				Vector1_32EE7E3F("Glow Strength", Float) = 1
				[NonModifiableTextureData] [NoScaleOffset] _SampleTexture2D_3C02D866_Texture("Texture", 2D) = "white" {}
		
	}
	SubShader
	{
		Tags{ "RenderPipeline" = "LightweightPipeline"}
		Tags
		{
			"RenderType"="Opaque"
			"Queue"="Geometry"
		}
		
		Pass
		{
			Tags{"LightMode" = "LightweightForward"}
			
					Blend One Zero
		
					Cull Back
		
					ZTest LEqual
		
					ZWrite On
		
		
			HLSLPROGRAM
		    // Required to compile gles 2.0 with standard srp library
		    #pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x
			#pragma target 2.0
		
			// -------------------------------------
			// Lightweight Pipeline keywords
			#pragma multi_compile _ _ADDITIONAL_LIGHTS
			#pragma multi_compile _ _VERTEX_LIGHTS
			#pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
			#pragma multi_compile _ _SHADOWS_ENABLED
		
			// -------------------------------------
			// Unity defined keywords
			#pragma multi_compile _ DIRLIGHTMAP_COMBINED
			#pragma multi_compile _ LIGHTMAP_ON
			#pragma multi_compile_fog
		
			//--------------------------------------
			// GPU Instancing
			#pragma multi_compile_instancing
		
		    #pragma vertex vert
			#pragma fragment frag
		
			
		
			#include "LWRP/ShaderLibrary/Core.hlsl"
			#include "LWRP/ShaderLibrary/Lighting.hlsl"
			#include "CoreRP/ShaderLibrary/Color.hlsl"
			#include "CoreRP/ShaderLibrary/UnityInstancing.hlsl"
			#include "ShaderGraphLibrary/Functions.hlsl"
		
								float Vector1_32EE7E3F;
							TEXTURE2D(_SampleTexture2D_3C02D866_Texture); SAMPLER(sampler_SampleTexture2D_3C02D866_Texture);
					
							struct SurfaceInputs{
								float3 ObjectSpaceNormal;
								float3 WorldSpaceNormal;
								float3 TangentSpaceNormal;
								float3 ObjectSpaceTangent;
								float3 ObjectSpaceBiTangent;
								float3 WorldSpaceViewDirection;
								half4 uv0;
							};
					
					
					        void Unity_Cosine_float(float In, out float Out)
					        {
					            Out = cos(In);
					        }
					
					        void Unity_FresnelEffect_float(float3 Normal, float3 ViewDir, float Power, out float Out)
					        {
					            Out = pow((1.0 - saturate(dot(normalize(Normal), normalize(ViewDir)))), Power);
					        }
					
					        void Unity_Multiply_float (float4 A, float4 B, out float4 Out)
					        {
					            Out = A * B;
					        }
					
							struct GraphVertexInput
							{
								float4 vertex : POSITION;
								float3 normal : NORMAL;
								float4 tangent : TANGENT;
								float4 texcoord0 : TEXCOORD0;
								float4 texcoord1 : TEXCOORD1;
								UNITY_VERTEX_INPUT_INSTANCE_ID
							};
					
							struct SurfaceDescription{
								float3 Albedo;
								float3 Normal;
								float3 Emission;
								float Metallic;
								float Smoothness;
								float Occlusion;
								float Alpha;
								float AlphaClipThreshold;
							};
					
							GraphVertexInput PopulateVertexData(GraphVertexInput v){
								return v;
							}
					
							SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
								SurfaceDescription surface = (SurfaceDescription)0;
								float4 _SampleTexture2D_3C02D866_RGBA = SAMPLE_TEXTURE2D(_SampleTexture2D_3C02D866_Texture, sampler_SampleTexture2D_3C02D866_Texture, IN.uv0.xy);
								float _SampleTexture2D_3C02D866_R = _SampleTexture2D_3C02D866_RGBA.r;
								float _SampleTexture2D_3C02D866_G = _SampleTexture2D_3C02D866_RGBA.g;
								float _SampleTexture2D_3C02D866_B = _SampleTexture2D_3C02D866_RGBA.b;
								float _SampleTexture2D_3C02D866_A = _SampleTexture2D_3C02D866_RGBA.a;
								float _Cosine_700BAD3_Out;
								Unity_Cosine_float(_SinTime.w, _Cosine_700BAD3_Out);
								float _FresnelEffect_C390FFB2_Out;
								Unity_FresnelEffect_float(IN.WorldSpaceNormal, IN.WorldSpaceViewDirection, _Cosine_700BAD3_Out, _FresnelEffect_C390FFB2_Out);
								float4 Color_AF9E3E = IsGammaSpace() ? float4(0.6994085, 1, 0.6556604, 0) : float4(SRGBToLinear(float3(0.6994085, 1, 0.6556604)), 0);
								float4 _Multiply_F94F76C7_Out;
								Unity_Multiply_float((_FresnelEffect_C390FFB2_Out.xxxx), Color_AF9E3E, _Multiply_F94F76C7_Out);
								
								surface.Albedo = (_SampleTexture2D_3C02D866_RGBA.xyz);
								surface.Normal = IN.TangentSpaceNormal;
								surface.Emission = (_Multiply_F94F76C7_Out.xyz);
								surface.Metallic = 0;
								surface.Smoothness = 0.5;
								surface.Occlusion = 1;
								surface.Alpha = 1;
								surface.AlphaClipThreshold = 0;
								return surface;
							}
					
		
		
			struct GraphVertexOutput
		    {
		        float4 clipPos                : SV_POSITION;
		        DECLARE_LIGHTMAP_OR_SH(lightmapUV, vertexSH, 0);
				half4 fogFactorAndVertexLight : TEXCOORD1; // x: fogFactor, yzw: vertex light
		    	float4 shadowCoord            : TEXCOORD2;
		        			float3 WorldSpaceNormal : TEXCOORD3;
					float3 WorldSpaceTangent : TEXCOORD4;
					float3 WorldSpaceBiTangent : TEXCOORD5;
					float3 WorldSpaceViewDirection : TEXCOORD6;
					float3 WorldSpacePosition : TEXCOORD7;
					half4 uv0 : TEXCOORD8;
					half4 uv1 : TEXCOORD9;
		
		        UNITY_VERTEX_INPUT_INSTANCE_ID
		    };
		
		    GraphVertexOutput vert (GraphVertexInput v)
			{
			    v = PopulateVertexData(v);
		
		        GraphVertexOutput o = (GraphVertexOutput)0;
		
		        UNITY_SETUP_INSTANCE_ID(v);
		    	UNITY_TRANSFER_INSTANCE_ID(v, o);
		
		        			o.WorldSpaceNormal = mul(v.normal,(float3x3)UNITY_MATRIX_I_M);
					o.WorldSpaceTangent = mul((float3x3)UNITY_MATRIX_M,v.tangent.xyz);
					o.WorldSpaceBiTangent = normalize(cross(o.WorldSpaceNormal, o.WorldSpaceTangent.xyz) * v.tangent.w);
					o.WorldSpaceViewDirection = SafeNormalize(_WorldSpaceCameraPos.xyz - mul(GetObjectToWorldMatrix(), float4(v.vertex.xyz, 1.0)).xyz);
					o.WorldSpacePosition = mul(UNITY_MATRIX_M,v.vertex).xyz;
					o.uv0 = v.texcoord0;
					o.uv1 = v.texcoord1;
		
		
				float3 lwWNormal = TransformObjectToWorldNormal(v.normal);
				float3 lwWorldPos = TransformObjectToWorld(v.vertex.xyz);
				float4 clipPos = TransformWorldToHClip(lwWorldPos);
		
		 		// We either sample GI from lightmap or SH.
			    // Lightmap UV and vertex SH coefficients use the same interpolator ("float2 lightmapUV" for lightmap or "half3 vertexSH" for SH)
		        // see DECLARE_LIGHTMAP_OR_SH macro.
			    // The following funcions initialize the correct variable with correct data
			    OUTPUT_LIGHTMAP_UV(v.texcoord1, unity_LightmapST, o.lightmapUV);
			    OUTPUT_SH(lwWNormal, o.vertexSH);
		
			    half3 vertexLight = VertexLighting(lwWorldPos, lwWNormal);
			    half fogFactor = ComputeFogFactor(clipPos.z);
			    o.fogFactorAndVertexLight = half4(fogFactor, vertexLight);
			    o.clipPos = clipPos;
		
			    #ifdef _SHADOWS_ENABLED
				#if SHADOWS_SCREEN
					o.shadowCoord = ComputeShadowCoord(clipPos);
				#else
					o.shadowCoord = TransformWorldToShadowCoord(lwWorldPos);
				#endif
				#endif
				
				return o;
			}
		
			half4 frag (GraphVertexOutput IN) : SV_Target
		    {
		    	UNITY_SETUP_INSTANCE_ID(IN);
		
		    				float3 WorldSpaceNormal = normalize(IN.WorldSpaceNormal);
					float3 WorldSpaceTangent = IN.WorldSpaceTangent;
					float3 WorldSpaceBiTangent = IN.WorldSpaceBiTangent;
					float3 WorldSpaceViewDirection = normalize(IN.WorldSpaceViewDirection);
					float3 WorldSpacePosition = IN.WorldSpacePosition;
					float3x3 tangentSpaceTransform = float3x3(WorldSpaceTangent,WorldSpaceBiTangent,WorldSpaceNormal);
					float3 ObjectSpaceNormal = mul(WorldSpaceNormal,(float3x3)UNITY_MATRIX_M);
					float3 TangentSpaceNormal = mul(WorldSpaceNormal,(float3x3)tangentSpaceTransform);
					float3 ObjectSpaceTangent = mul((float3x3)UNITY_MATRIX_I_M,WorldSpaceTangent);
					float3 ObjectSpaceBiTangent = mul((float3x3)UNITY_MATRIX_I_M,WorldSpaceBiTangent);
					float4 uv0 = IN.uv0;
					float4 uv1 = IN.uv1;
		
		
		        SurfaceInputs surfaceInput = (SurfaceInputs)0;
		        			surfaceInput.ObjectSpaceNormal = ObjectSpaceNormal;
					surfaceInput.WorldSpaceNormal = WorldSpaceNormal;
					surfaceInput.TangentSpaceNormal = TangentSpaceNormal;
					surfaceInput.ObjectSpaceTangent = ObjectSpaceTangent;
					surfaceInput.ObjectSpaceBiTangent = ObjectSpaceBiTangent;
					surfaceInput.WorldSpaceViewDirection = WorldSpaceViewDirection;
					surfaceInput.uv0 = uv0;
		
		
		        SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
		
				float3 Albedo = float3(0.5, 0.5, 0.5);
				float3 Specular = float3(0, 0, 0);
				float Metallic = 1;
				float3 Normal = float3(0, 0, 1);
				float3 Emission = 0;
				float Smoothness = 0.5;
				float Occlusion = 1;
				float Alpha = 1;
				float AlphaClipThreshold = 0;
		
		        			Albedo = surf.Albedo;
					Normal = surf.Normal;
					Emission = surf.Emission;
					Metallic = surf.Metallic;
					Smoothness = surf.Smoothness;
					Occlusion = surf.Occlusion;
					Alpha = surf.Alpha;
					AlphaClipThreshold = surf.AlphaClipThreshold;
		
		
				InputData inputData;
				inputData.positionWS = WorldSpacePosition;
		
		#ifdef _NORMALMAP
			    inputData.normalWS = TangentToWorldNormal(Normal, WorldSpaceTangent, WorldSpaceBiTangent, WorldSpaceNormal);
		#else
		    #if !SHADER_HINT_NICE_QUALITY
		        inputData.normalWS = WorldSpaceNormal;
		    #else
			    inputData.normalWS = normalize(WorldSpaceNormal);
		    #endif
		#endif
		
		#if !SHADER_HINT_NICE_QUALITY
			    // viewDirection should be normalized here, but we avoid doing it as it's close enough and we save some ALU.
			    inputData.viewDirectionWS = WorldSpaceViewDirection;
		#else
			    inputData.viewDirectionWS = normalize(WorldSpaceViewDirection);
		#endif
		
			    inputData.shadowCoord = IN.shadowCoord;
		
			    inputData.fogCoord = IN.fogFactorAndVertexLight.x;
			    inputData.vertexLighting = IN.fogFactorAndVertexLight.yzw;
			    inputData.bakedGI = SAMPLE_GI(IN.lightmapUV, IN.vertexSH, inputData.normalWS);
		
				half4 color = LightweightFragmentPBR(
					inputData, 
					Albedo, 
					Metallic, 
					Specular, 
					Smoothness, 
					Occlusion, 
					Emission, 
					Alpha);
		
				// Computes fog factor per-vertex
		    	ApplyFog(color.rgb, IN.fogFactorAndVertexLight.x);
		
		#if _AlphaClip
				clip(Alpha - AlphaClipThreshold);
		#endif
				return color;
		    }
		
			ENDHLSL
		}
		
		Pass
		{
			Tags{"LightMode" = "ShadowCaster"}
		
			ZWrite On
			ZTest LEqual
			Cull Back
		
			HLSLPROGRAM
			// Required to compile gles 2.0 with standard srp library
			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x
			#pragma target 2.0
		
			// -------------------------------------
			// Material Keywords
			#pragma shader_feature _ALPHATEST_ON
		
			//--------------------------------------
			// GPU Instancing
			#pragma multi_compile_instancing
		
			#pragma vertex ShadowPassVertex
			#pragma fragment ShadowPassFragment
		
			#include "LWRP/ShaderLibrary/InputSurfacePBR.hlsl"
			#include "LWRP/ShaderLibrary/LightweightPassShadow.hlsl"
		
			ENDHLSL
		}
		
		Pass
		{
			Tags{"LightMode" = "DepthOnly"}
		
			ZWrite On
			ColorMask 0
			Cull Back
		
			HLSLPROGRAM
			// Required to compile gles 2.0 with standard srp library
			#pragma prefer_hlslcc gles
			#pragma target 2.0
		
			#pragma vertex DepthOnlyVertex
			#pragma fragment DepthOnlyFragment
		
			// -------------------------------------
			// Material Keywords
			#pragma shader_feature _ALPHATEST_ON
		
			//--------------------------------------
			// GPU Instancing
			#pragma multi_compile_instancing
		
			#include "LWRP/ShaderLibrary/InputSurfacePBR.hlsl"
			#include "LWRP/ShaderLibrary/LightweightPassDepthOnly.hlsl"
			ENDHLSL
		}
		
		// This pass it not used during regular rendering, only for lightmap baking.
		Pass
		{
			Tags{"LightMode" = "Meta"}
		
			Cull Off
		
			HLSLPROGRAM
			// Required to compile gles 2.0 with standard srp library
			#pragma prefer_hlslcc gles
		
			#pragma vertex LightweightVertexMeta
			#pragma fragment LightweightFragmentMeta
		
			#pragma shader_feature _SPECULAR_SETUP
			#pragma shader_feature _EMISSION
			#pragma shader_feature _METALLICSPECGLOSSMAP
			#pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
			#pragma shader_feature EDITOR_VISUALIZATION
		
			#pragma shader_feature _SPECGLOSSMAP
		
			#include "LWRP/ShaderLibrary/InputSurfacePBR.hlsl"
			#include "LWRP/ShaderLibrary/LightweightPassMetaPBR.hlsl"
			ENDHLSL
		}
		
	}
	
	FallBack "Hidden/InternalErrorShader"
}
