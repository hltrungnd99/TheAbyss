using UnityEngine;
using UnityEngine.AI;

public class AreaBaker : MonoBehaviour
{
    public NavMeshData navMeshData;
    public NavMeshData navMeshData2;

    void Start()
    {
        // Kiểm tra xem NavMeshData đã được gán chưa
        if (navMeshData == null)
        {
            Debug.LogError("NavMeshData is not assigned!");
            return;
        }

        navMeshData.position = new Vector3(0, 0, 74.7f);
        navMeshData2.position = new Vector3(0, 0, 0);

        // Tạo một NavMeshDataInstance và gán NavMeshData cho scene
        NavMeshDataInstance navMeshInstance = NavMesh.AddNavMeshData(navMeshData);
        NavMesh.AddNavMeshData(navMeshData2);

        // Bạn có thể thực hiện các bước khác ở đây nếu cần thiết
    }
}