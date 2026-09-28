using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject m_player;
    public float m_followSpeed = 1;

    void Update()
    {
        Vector3 newCameraPosition = new Vector3(transform.position.x, transform.position.y,
            Camera.main.transform.position.z);
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,
            newCameraPosition, Time.deltaTime * m_followSpeed);
    }
}
