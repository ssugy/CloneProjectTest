Shader "Custom/Brick1_lambert"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Alpha ("test", Range(0, 1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
        LOD 200
        Zwrite off
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        //#pragma surface surf Lambert fullforwardshadows    // 여기에 Lambert추가(스탠다드 제거) 조명의 변경이기 때문임.
        #pragma surface surf Lambert alpha:fade    // 램버트 알파 하려면 이렇게 바꿔야된다.

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        //half _Glossiness; // 램버트 조명 -> SurfaceOutput 구조체로 변경 -> 메탈릭과 스무스니스 적용 파라미터가 없음.-> 그래서 여기 파라미터도 의미없음
        //half _Metallic;
        fixed4 _Color;
        half _Alpha;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o) // 램버트 조명에서는 여기 부분도 SurfaceOutput으로 변경하였다. (구조체가 바껴서, 사용할 수 있는 매개변수도 변경됨)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;       // 램버트 조명(환경광)방식은 메탈리과 스무스니스를 사용하면 안됨.
            //o.Smoothness = _Glossiness;   // 환경광 : 일정한 밝기로 물체를 전부 칠하는 빛으로, 물체 면의 방향이나 빛의 방향이 전혀 영향을 주지 않는다.
            o.Alpha = _Alpha;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
