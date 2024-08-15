using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panBorderThickness;

    [Header("Camera Speeds")]
    public float panSpeed;
    public float scrollSpeed;
    public float rotateSpeed;

    [Header("Min and Max Values")]
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    public Vector3 startPos;
    public Quaternion startRot;

    void Start()
    {
        startPos = this.transform.position;
        startRot = this.transform.rotation;
    }

    void Update()
    {
        if (GameManager.gameOver)
        {
            this.enabled = false;
            return;
        }
        
        if (!MapGenerator.loaded)
        {
            return;
        }

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("q"))
        {
            transform.Rotate(new Vector3(0 , 1, 0) * rotateSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(new Vector3(0, -1, 0) * rotateSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("r"))
        {
            transform.position = startPos;
            transform.rotation = startRot;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}
