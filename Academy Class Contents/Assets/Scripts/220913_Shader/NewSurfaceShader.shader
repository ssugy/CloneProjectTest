Shader "Custom/NewSurfaceShader"
{
    /**
    * 외부에 공개되는 변수. -> 연산에 사용하기 위함.
    */
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
        _Alpha("Alpha", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        //#pragma surface surf Standard fullforwardshadows  //기본형-알파 적용안됨
        /*
        1. surface 
        2. surf : 함수이름(하단에 있음)
        3. Standard : 조명 설정
        4. fullforwardshadows : 그림자 설정
        5. alpha:fade : 알파 설정
        */
        #pragma surface surf Standard alpha:fade    //알파 적용됨

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0  // 쉐이더 모델 3.0사용

        /*
        연산에 사용할 변수 선언 : 외부에서 받은 데이터를 연산에 사용하기 위해서는 데이터를 선언 해 줘야한다.
        기본 데이터를 선언해서 자료형을 지정하면 된다.
        */
        sampler2D _MainTex; // 2D자료형을 사용하기 위해서는 sampler2D를 사용해야 한다.

        /*
        그래픽 카드에 전달되는 입력 구조체 데이터.
        */
        struct Input
        {
            float2 uv_MainTex;  // 텍스처에 전달되는 UV좌표
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;  // 컬러값에는 fixed4자료형을 사용한다.(half보다 더 작은 실수) float > half > fixed4
        fixed _Alpha;    // 여기에 전역변수처럼 선언을 해야지 surf함수에서도 사용이 가능하다.

        // GPU인스턴싱 기능은 상당히 강력한 기능이다. 사용 할 수 있게 쉐이터 코드 작성(속도가 상당히 높아짐)
        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        /*
        실제 연산을 해주는 함수. 매개변수 잘 보기
        inout : 함수 안으로 들어올 수 있고 나갈 수 있는 키워드
        SurfaceOutputStandard : o에 연산한대로 출력을 해준다.
        텍스처가 화면에 나타나려면, 연산을 해줘야 한다. 그 연산을 해주는 함수가 tex2D함수이다.
        */
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;

            /**
            * 조명연산을 고려하지 않은 Blue값을 갖는 셰이더 코드를 작성하시오
            */
            o.Emission = fixed3(0, 0, 1);
            o.Alpha = _Alpha;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
