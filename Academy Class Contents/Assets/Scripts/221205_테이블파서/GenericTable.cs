using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTable<T> where T: class
{
    private T t;        // 이게 객체임. Monster, Character, Npc..등등
    public T data { get; set; }
    
    // 1. 생성자 처리
    public GenericTable() { }
    public GenericTable(T _t) { t = _t; }
    
    // 2. 입출력 함수 처리
    public T LoadData() { return t; }
    public void SaveData(T _t) { }

    // 3. 이런방법인가
    //public T ShowTable<T>() {}
}
