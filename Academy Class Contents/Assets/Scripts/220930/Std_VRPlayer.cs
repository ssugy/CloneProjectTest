using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Std_VRPlayer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private Vector3 end;
    private Vector3 targetPosition;
    private float moveSpeed;

    private void Start()
    {
        lineRenderer.SetPosition(0, transform.position);    // 0�� ������ ����
        end = transform.position;
        moveSpeed = 6f;
        FindTargetPosition();

        // 4�ʸ��� ť�����
        InvokeRepeating("SpawnMonster", 1, 4);
    }

    void FindTargetPosition()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, Mathf.Infinity))
        {
            targetPosition = hitInfo.point + transform.forward * 0.5f;
        }

        // ������ ������ �ε����� �� ������� �϶�� ����. �Ʒ� ����� �������� üũ�ϰԵǼ� �ٸ�
        //int monsterLayerMask = 1 << 7;
        //if (Physics.Raycast(transform.position, transform.forward, out hitInfo, Mathf.Infinity, monsterLayerMask))
        //{
        //    hitInfo.transform.GetComponent<Std_LineMonster>().DestroyMonster();
        //}
    }

    public MeshFilter test;
    public MeshCollider mCollider;

    public void GenerateMeshCollider()
    {
        Mesh mesh = new Mesh();
        
        lineRenderer.BakeMesh(mesh, false);
        test.mesh = mesh;

        // if you need collisions on both sides of the line, simply duplicate & flip facing the other direction!
        // This can be optimized to improve performance ;)
        int[] meshIndices = mesh.GetIndices(0);
        int[] newIndices = new int[meshIndices.Length * 2];

        int j = meshIndices.Length - 1;
        for (int i = 0; i < meshIndices.Length; i++)
        {
            newIndices[i] = meshIndices[i];
            newIndices[meshIndices.Length + i] = meshIndices[j];
        }
        mesh.SetIndices(newIndices, MeshTopology.Triangles, 0);

        mCollider.sharedMesh = mesh;
    }

    void DebugDrawRay()
    {
        Debug.DrawLine(transform.position, transform.forward, Color.blue);
    }

    private void Update()
    {
        DebugDrawRay();
        FindTargetPosition();
        end = Vector3.MoveTowards(end, targetPosition, Time.deltaTime * moveSpeed);
        lineRenderer.SetPosition(3, end);
        GenerateMeshCollider();
    }


    /**
     * ���Ͽ� ���Ͱ� 4�ʸ��� �����ǰ�, �÷��̾�� �ٰ���.
     * ������ ������ ������� �����
     */

    public Transform[] spawnTransforms; // �ܺο��� ��������
    private void SpawnMonster()
    {
        for (int i = 0; i < spawnTransforms.Length; i++)
        {
            GameObject monster = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            monster.transform.position = spawnTransforms[i].position;
            monster.transform.SetParent(spawnTransforms[i]);
            monster.AddComponent<Std_LineMonster>();
            monster.GetComponent<Collider>().isTrigger = true;
            monster.layer = 7;
        }
    }
}
