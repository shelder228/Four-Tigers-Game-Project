using UnityEngine;

public class CalculatingPhoneSizeForWall : MonoBehaviour
{
    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;
    [SerializeField] private Transform downWall;
    [SerializeField] private Transform topWall;
    public float colliderWidth = 0.1f; 
    public float padding = 0.1f; 

    void Start()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float screenWorldWidth = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, 0, 0)).x * 2f;
        float screenWorldHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, screenHeight, 0)).y * 2f;

        Vector3 leftWallPosition = new Vector3(-(screenWorldWidth / 2f) + (colliderWidth / 2f) + padding, 0, 0);
        Vector3 rightWallPosition = new Vector3((screenWorldWidth / 2f) - (colliderWidth / 2f) - padding, 0, 0);
        Vector3 bottomWallPosition = new Vector3(0, -(screenWorldHeight / 2f) + (colliderWidth / 2f) + padding, 0);
        Vector3 topWallPosition = new Vector3(0, (screenWorldHeight / 2f) - (colliderWidth / 2f) + padding * 7, 0);

        if (leftWall != null)
            leftWall.position = leftWallPosition;
        
        if (rightWall != null)
            rightWall.position = rightWallPosition;

        if (downWall != null)
            downWall.position = bottomWallPosition;
        
        if (topWall != null)
            topWall.position = topWallPosition;
    }
}

