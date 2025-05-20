using UnityEngine;

public class Fruit : MonoBehaviour
{
    public static bool isAnythingPicked = false;
    [SerializeField] private const float minDrag = 2f;
    [SerializeField] private const float maxForce = 10f;
    private Rigidbody2D rb;
    private Vector2 mouseDownPos;
    private PolygonCollider2D collider;
    
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.sleepMode = RigidbodySleepMode2D.StartAsleep;
        rb.Sleep();

        collider = gameObject.GetComponent<PolygonCollider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<PolygonCollider2D>();
        }
        collider.isTrigger = true;
        PhysicsMaterial2D mat = new PhysicsMaterial2D();
        mat.bounciness = 0.1f;
        mat.friction = 0.4f;
        collider.sharedMaterial = mat;
    }  

    private void OnMouseDown()
    {
        if (isAnythingPicked)
            return;

        isAnythingPicked = true;
        mouseDownPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        if (!isAnythingPicked)
            return;

        Vector2 mouseUpPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dragVector = mouseUpPos - mouseDownPos;
        if (dragVector.sqrMagnitude >= minDrag)
        {
            rb.WakeUp();
            Vector2 dragForce = dragVector;
            collider.isTrigger = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(dragForce, ForceMode2D.Impulse);
        }
        isAnythingPicked = false;
    }

}