using UnityEngine;
public class FollowWindow : MonoBehaviour
{
    private Transform cameraTransform; //相机
    public TextAnchor windowAnchor = TextAnchor.UpperCenter; //偏移类型
    public float windowDistance = 2f; //跟随的距离
    public float moveThreshold = 1f; //移动阈值
    public float MoveSpeed = 2f; //跟随速度

    private Transform window; //跟随的窗体
    private Vector2 windowOffset = new(0.5f, 0.5f); //偏移量
    private bool m_Follow;
    
    protected void Awake()
    {
        window = transform;
        if (cameraTransform == null) cameraTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        resetWindowPositon();
    }

    void LateUpdate()
    {
        setWindowPositon();
    }

    private void resetWindowPositon()
    {
        window.position = CalculateWindowPosition(cameraTransform);
        window.rotation = cameraTransform.rotation;
    }

    private void setWindowPositon()
    {
        float t = Time.deltaTime * MoveSpeed;
        Vector3 targetPosition = CalculateWindowPosition(cameraTransform);
        Quaternion targetRotation = cameraTransform.rotation;
        var distance = Vector3.Distance(window.position, targetPosition);
        if (distance > moveThreshold)
        {
            m_Follow = true;
        }
        else if (distance < 0.01)
        {
            m_Follow = false;
        }
        
        if (m_Follow)
        {
            window.position = Vector3.Lerp(window.position, targetPosition, t);
            window.rotation = Quaternion.Slerp(window.rotation, targetRotation, t);
        }
    }

    private Vector3 CalculateWindowPosition(Transform cameraTransform)
    {
        float windowDistance = Mathf.Max(16.0f / Camera.main.fieldOfView, Camera.main.nearClipPlane + this.windowDistance);
        Vector3 position = cameraTransform.position + (cameraTransform.forward * windowDistance);
        Vector3 horizontalOffset = cameraTransform.right * windowOffset.x;
        Vector3 verticalOffset = cameraTransform.up * windowOffset.y;

        switch (windowAnchor)
        {
            case TextAnchor.UpperLeft:
                position += verticalOffset - horizontalOffset;
                break;
            case TextAnchor.UpperCenter:
                position += verticalOffset;
                break;
            case TextAnchor.UpperRight:
                position += verticalOffset + horizontalOffset;
                break;
            case TextAnchor.MiddleLeft:
                position -= horizontalOffset;
                break;
            case TextAnchor.MiddleRight:
                position += horizontalOffset;
                break;
            case TextAnchor.LowerLeft:
                position -= verticalOffset + horizontalOffset;
                break;
            case TextAnchor.LowerCenter:
                position -= verticalOffset;
                break;
            case TextAnchor.LowerRight:
                position -= verticalOffset - horizontalOffset;
                break;
        }

        return position;
    }
}