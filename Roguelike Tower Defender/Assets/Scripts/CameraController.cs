using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Speeds")]
    public float panSpeed;
    public float scrollSpeed;
    public float rotateSpeed;

    [Header("Min/Max Values")]
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    private Vector3 startPos;
    private Quaternion startRot;

    void Start()
    {
        // Set the start position and rotation variables to the current camera transform values
        startPos = this.transform.position;
        startRot = this.transform.rotation;
    }

    void Update()
    {
        // If the game is over
        if (GameManager.gameOver)
        {
            // Disable the camera and do not execute further code in the Update method
            this.enabled = false;
            return;
        }
        
        // If the map isn't loaded
        if (!MapGenerator.loaded)
        {
            // Don't run further code in the Update method
            return;
        }

        // If the W key is pressed
        if (Input.GetKey("w") && transform.position.z != minZ)
        {
            // Move forward
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime);
        }
        // If the S key is pressed
        if (Input.GetKey("s") && transform.position.z != maxZ)
        {
            // Move backward
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime);
        }
        // If the D key is pressed
        if (Input.GetKey("d") && transform.position.x != minX)
        {
            // Move right
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime);
        }
        // If the A key is pressed
        if (Input.GetKey("a") && transform.position.x != maxX)
        {
            // Move left
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime);
        }
        
        // If the Q key is pressed
        if (Input.GetKey("q"))
        {
            transform.Rotate(new Vector3(0 , -1, 0) * rotateSpeed * Time.deltaTime);
        }
        // If the E key is pressed
        if (Input.GetKey("e"))
        {
            transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
        }
        
        // If the R key is pressed
        if (Input.GetKey("r"))
        {
            // Reset the camera position and rotation
            transform.position = startPos;
            transform.rotation = startRot;
        }

        // Get the amount of input on the scrollwheel, store it in a variable
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Get the current camera position, store it in a variable
        Vector3 pos = transform.position;

        // Change the Y value of pos based on scrollwheel input
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        // Don't let the camera transform X,Y and Z values be more or less than the specified amounts
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        // Move the camera
        transform.position = pos;
    }
}
