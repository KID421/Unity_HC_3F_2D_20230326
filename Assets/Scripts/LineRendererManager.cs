using UnityEngine;

public class LineRendererManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask layer;
    private LineRenderer line;
    private int count = 1;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, transform.position);
        UpdateRay(transform.position, transform.right);
    }

    private void Update()
    {

    }

    private void UpdateRay(Vector3 original, Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(original, direction, 100f, layer);

        //if (hit.point == (Vector2)line.GetPosition(count - 1)) return;

        if (hit)
        {
            UpdateLinePoint(direction, hit);
        }
    }

    private void UpdateLinePoint(Vector3 direction, RaycastHit2D hit)
    {
        hit.collider.gameObject.layer = 0;
        count++;
        line.positionCount = count;
        line.SetPosition(count - 1, hit.point);
        Vector2 newDirection = Vector2.Reflect(direction, hit.normal);
        UpdateRay(hit.point, newDirection);
    }
}
