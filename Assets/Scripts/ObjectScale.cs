using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // ���� ī�޶� ã���ϴ�.
        mainCamera = Camera.main;

        // ȭ�� ũ�Ⱑ ����� ������ ũ�⸦ �����ϱ� ���� Update �޼��带 ����մϴ�.
        UpdateObjectSize();
    }

    void Update()
    {
        // ȭ�� ũ�Ⱑ ����� ������ ������Ʈ�� ũ�⸦ �����մϴ�.
        UpdateObjectSize();
    }

    void UpdateObjectSize()
    {
        // ���� ī�޶��� �þ� ������ ���̸� �����ɴϴ�.
        float cameraHeight = 2f * mainCamera.orthographicSize;

        // ������Ʈ�� ũ�⸦ ȭ���� ���� ũ�⿡ �°� �����մϴ�.
        transform.localScale = new Vector3(cameraHeight / 50f, cameraHeight / 50f, 1f);
        // ���⼭ 10f�� ���ϴ� ȭ�鿡���� ������Ʈ ũ�⸦ �����ϱ� ���� ����Դϴ�.
        // �ʿ信 ���� ���� �����Ͽ� ������Ʈ�� ũ�⸦ ������ �� �ֽ��ϴ�.
    }
}