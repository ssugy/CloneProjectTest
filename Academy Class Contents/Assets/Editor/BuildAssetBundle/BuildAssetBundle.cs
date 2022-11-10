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
         * 1. 아웃풋 옵션
         * 2. 빌드옵션 : 지금은 빌드옵션을 신경안써도 에셋번들 만들 수 있다.
         * 3. 빌드타겟 : 안드로이드냐 등의 플랫폼.
         */
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles",
                                    BuildAssetBundleOptions.None,
                                    //BuildTarget.Android
                                    BuildTarget.StandaloneWindows64   // 64비트 윈도우용
                                    );
    }
}
