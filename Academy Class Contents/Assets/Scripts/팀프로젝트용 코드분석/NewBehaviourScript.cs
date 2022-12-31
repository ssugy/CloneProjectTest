using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class NewBehaviourScript : MonoBehaviour 
{

    IEnumerator LoadBundle_New()
    {
        string url = "file:///" + Application.dataPath + "/AssetBundles/" + "cube.assetbundle";
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return www.SendWebRequest();
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
        var prefab = bundle.LoadAsset<GameObject>("Cube");
        GameObject obj = Instantiate(prefab);
        obj.transform.position = Vector3.zero;
    }

    
}
