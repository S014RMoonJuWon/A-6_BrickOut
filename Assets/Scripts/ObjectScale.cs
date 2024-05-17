using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // 메인 카메라를 찾습니다.
        mainCamera = Camera.main;

        // 화면 크기가 변경될 때마다 크기를 조절하기 위해 Update 메서드를 사용합니다.
        UpdateObjectSize();
    }

    void Update()
    {
        // 화면 크기가 변경될 때마다 오브젝트의 크기를 조절합니다.
        UpdateObjectSize();
    }

    void UpdateObjectSize()
    {
        // 현재 카메라의 시야 영역의 높이를 가져옵니다.
        float cameraHeight = 2f * mainCamera.orthographicSize;

        // 오브젝트의 크기를 화면의 세로 크기에 맞게 조절합니다.
        transform.localScale = new Vector3(cameraHeight / 50f, cameraHeight / 50f, 1f);
        // 여기서 10f는 원하는 화면에서의 오브젝트 크기를 조절하기 위한 상수입니다.
        // 필요에 따라 값을 조정하여 오브젝트의 크기를 조절할 수 있습니다.
    }
}