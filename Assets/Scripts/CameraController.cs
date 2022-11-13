using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject objectToFollow;
    public BoxCollider2D worldBounds;

    // private float xMax;
    // private float xMin;
    // private float yMax;
    // private float yMin;

    // private float camX;
    // private float camY;
    // private float camRatio;
    // private float camSize;

    public float speed = 2.0f;

    private void Start()
    {
        // worldBounds = GameObject.FindGameObjectWithTag("Bounds").GetComponent<BoxCollider2D>();
        // xMin = worldBounds.bounds.min.x;
        // xMax = worldBounds.bounds.max.x;
        // yMin = worldBounds.bounds.min.y;
        // yMax = worldBounds.bounds.max.y;

        // mainCamera = gameObject.GetComponent<Camera>();

        // camSize = gameObject.GetComponent<Camera>().orthographicSize;
        // camRatio = (xMax + camSize) / 2.0f;

    }

    void Update()
    {
        float interpolation = speed * Time.deltaTime;
        // camY = Mathf.Clamp(objectToFollow.transform.position.y, yMin + camSize, yMax - camSize);
        // camX = Mathf.Clamp(objectToFollow.transform.position.x, xMin + camRatio, xMax - camRatio);
        // gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(camX, camY, gameObject.transform.position.z), interpolation);

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y + 5, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

        this.transform.position = position;
    }
}
