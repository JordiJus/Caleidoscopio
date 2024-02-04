using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0f, 1f)] public float deadZoneFactor = 0.5f;
    [Range(0f, 1f)] public float smoothFactor = 0.1f;
    private float dzH, dzW;
    private Transform target;
    private Bounds deadZoneCube;
    // Start is called before the first frame update
    void Start()
    {
        dzH = Camera.main.orthographicSize * deadZoneFactor;
        dzW = dzH * Camera.main.aspect;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        deadZoneCube = new Bounds(transform.position, new Vector3(dzW * 2, dzH * 2, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        float incrX, incrY;
        if (!IsInDeadZone(out incrX, out incrY))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(incrX, incrY, 0f), smoothFactor);
        }
    }

    private bool IsInDeadZone(out float incrX, out float incrY)
    {
        deadZoneCube.center = transform.position;
        if (!deadZoneCube.Contains(target.position))
        {
            Vector3 cP = deadZoneCube.ClosestPoint(target.position);
            incrX = target.position.x - cP.x;
            incrY = target.position.y - cP.y;
            return false;
        }
        incrX = incrY = 0;
        return true;
    }

    private void OnDrawGizmosSelected()
    {
        dzH = Camera.main.orthographicSize * deadZoneFactor;
        dzW = dzH * Camera.main.aspect;
        Gizmos.color = Color.magenta;
        //Gizmos.DrawLine(transform.position, transform.position+new Vector3(0f,dzH,0f));
        Gizmos.DrawWireCube(transform.position, new Vector3(2 * dzW, 2 * dzH, 1f));
    }
}
