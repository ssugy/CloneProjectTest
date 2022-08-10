using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std0810_Exam : MonoBehaviour
{
    List<MyCharacter> characters = new List<MyCharacter>();

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Camera.main.transform.position);

        GameObject tmp = GameObject.Find("TestCamera");
        Camera tmpCamera = tmp.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Move2();
    }

    void Move()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        print("x´Â " + x);
        print("y´Â " + y);

        Vector3 tmp = new Vector3(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z);

        tmp.y = tmp.y + y * Time.deltaTime *3f;
        tmp.x = tmp.x + x * Time.deltaTime * 3f;

        transform.position = tmp;

        // °Å¸®±¸ÇÏ±â

        float fDis = Vector3.Distance(new Vector3(10, 0, 0), transform.position);

        if (fDis < 1.0f)
        {

            Debug.Log("Æ¯Á¤ÁÂÇ¥ µµÂø");

        }
    }

    void Move2()
    {
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");

        print("x´Â " + x);
        print("y´Â " + y);

        Vector3 tmp = new Vector3(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z);

        tmp.x = tmp.x + x * 2f;
        tmp.y = tmp.y + y * 2f;

        Camera.main.transform.rotation = Quaternion.Euler(tmp);
    }

    //public MyCharacter obj;
    //public void DisplayPosition()

    //{

    //    Debug.Log(obj.gameObject.transform.position);

    //}

    //public void GetMobAnimator()

    //{

    //    Animator mobAni = obj.gameObject.GetComponent<Animator>();

    //}

    //public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //    float time = [6 - 2 ºóÄ­] % 1f;

    //    if (time >= [6 - 2ºóÄ­])

    //    {

    //    }

    //}

    private int num1;
    public int NUM1
    {
        get { return num1; }
        set { num1 = value; }
    }
}
