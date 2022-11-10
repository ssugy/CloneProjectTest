using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildAssetBundle
{
    [MenuItem("AssetBundle/SaveBundle")]
    static void SaveBundle()
    {
        /**
         * 1. �ƿ�ǲ �ɼ�
         * 2. ����ɼ� : ������ ����ɼ��� �Ű�Ƚᵵ ���¹��� ���� �� �ִ�.
         * 3. ����Ÿ�� : �ȵ���̵�� ���� �÷���.
         */
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles",
                                    BuildAssetBundleOptions.None,
                                    //BuildTarget.Android
                                    BuildTarget.StandaloneWindows64   // 64��Ʈ �������
                                    );
    }
}
