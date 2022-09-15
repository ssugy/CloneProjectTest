Shader "Custom/NewSurfaceShader"
{
    /**
    * �ܺο� �����Ǵ� ����. -> ���꿡 ����ϱ� ����.
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
        //#pragma surface surf Standard fullforwardshadows  //�⺻��-���� ����ȵ�
        /*
        1. surface 
        2. surf : �Լ��̸�(�ϴܿ� ����)
        3. Standard : ���� ����
        4. fullforwardshadows : �׸��� ����
        5. alpha:fade : ���� ����
        */
        #pragma surface surf Standard alpha:fade    //���� �����

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0  // ���̴� �� 3.0���

        /*
        ���꿡 ����� ���� ���� : �ܺο��� ���� �����͸� ���꿡 ����ϱ� ���ؼ��� �����͸� ���� �� ����Ѵ�.
        �⺻ �����͸� �����ؼ� �ڷ����� �����ϸ� �ȴ�.
        */
        sampler2D _MainTex; // 2D�ڷ����� ����ϱ� ���ؼ��� sampler2D�� ����ؾ� �Ѵ�.

        /*
        �׷��� ī�忡 ���޵Ǵ� �Է� ����ü ������.
        */
        struct Input
        {
            float2 uv_MainTex;  // �ؽ�ó�� ���޵Ǵ� UV��ǥ
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;  // �÷������� fixed4�ڷ����� ����Ѵ�.(half���� �� ���� �Ǽ�) float > half > fixed4
        fixed _Alpha;    // ���⿡ ��������ó�� ������ �ؾ��� surf�Լ������� ����� �����ϴ�.

        // GPU�ν��Ͻ� ����� ����� ������ ����̴�. ��� �� �� �ְ� ������ �ڵ� �ۼ�(�ӵ��� ����� ������)
        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        /*
        ���� ������ ���ִ� �Լ�. �Ű����� �� ����
        inout : �Լ� ������ ���� �� �ְ� ���� �� �ִ� Ű����
        SurfaceOutputStandard : o�� �����Ѵ�� ����� ���ش�.
        �ؽ�ó�� ȭ�鿡 ��Ÿ������, ������ ����� �Ѵ�. �� ������ ���ִ� �Լ��� tex2D�Լ��̴�.
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
            * �������� ������� ���� Blue���� ���� ���̴� �ڵ带 �ۼ��Ͻÿ�
            */
            o.Emission = fixed3(0, 0, 1);
            o.Alpha = _Alpha;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
