//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;

//public interface IReadData { void ReadData(string[] _datas); }

//// ���׸��� ����Ͽ� csv ���Ͽ��� ���ϴ� �����͸� �ε���.
//// new()�� ����� �� �ְ� IReadData �������̽��� �����ϴ� ���׸��� ����.
//public class TableParser_JY<T> where T : IReadData, new() 
//{        
//    public static List<T> TableParsing(string _filePath)
//    {
//        List<T> members = new();
//        using (StreamReader sr = new(_filePath))
//        {
//            string line = string.Empty;
//            line = sr.ReadLine();
//            while ((line = sr.ReadLine()) != null)
//            {                
//                T tmp = new();
//                tmp.ReadData(line.Split(','));
//                members.Add(tmp);                
//            }
//            sr.Close();
//        }
//        return members;
//    }    
//}

////[System.Serializable]
//public struct CharacterData : IReadData
//{
//    public int index;
//    public string name;
//    public float level;
//    public int str;
//    public int hp;
//    public void ReadData(string[] _datas)
//    {
//        index = int.Parse(_datas[0]);
//        name = _datas[1];
//        level = float.Parse(_datas[2]);
//        //str = int.Parse(_datas[3]);
//        //hp = int.Parse(_datas[4]);
//    }
//}

////[System.Serializable]
//public struct MonsterData : IReadData
//{
//    public int index;
//    public string name;
//    public float level;
//    public void ReadData(string[] _datas)
//    {
//        index = int.Parse(_datas[0]);
//        name = _datas[1];
//        level = float.Parse(_datas[2]);
//    }

//}

//[System.Serializable]
//public struct NPCCData : IReadData
//{
//    public int index;
//    public string name;
//    public void ReadData(string[] _datas)
//    {
//        index = int.Parse(_datas[0]);
//        name = _datas[1];
//    }
//}


