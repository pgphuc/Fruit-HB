using UnityEngine;

public enum State { OnBranch, Fallen, }

public class Tomato : MonoBehaviour
{
    [SerializeField] private const float minDrag = 0.5f;
    [SerializeField] private const float maxVelocity = 10f;

    public static bool isAnythingPicked = false;
    public bool isTomato = true;

    private State currentState;
    private Rigidbody2D rb;
    private Vector2 mouseDownPos;
    private PolygonCollider2D col;

    protected virtual void Start()
    {
        currentState = State.OnBranch;

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.sleepMode = RigidbodySleepMode2D.StartAsleep;
        rb.Sleep();

        col = gameObject.GetComponent<PolygonCollider2D>();
        if (col == null)
        {
            col = gameObject.AddComponent<PolygonCollider2D>();
        }
        col.isTrigger = true;

        PhysicsMaterial2D mat = new PhysicsMaterial2D();
        mat.bounciness = 0.6f;
        mat.friction = 0.4f;
        col.sharedMaterial = mat;
    }  

    private void OnMouseDown()
    {
        if (isAnythingPicked)
            return;
        isAnythingPicked = true;
        mouseDownPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        Debug.Log(isAnythingPicked);
        if (!isAnythingPicked)
            return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (currentState == State.OnBranch)
        {
            Vector2 dragVector = mousePos - mouseDownPos;
            if (dragVector.sqrMagnitude <= minDrag)
                return;

            if (isTomato)
                col.isTrigger = false;

            if (rb.velocity.sqrMagnitude >= maxVelocity)
            {
                SoundManager.instance.OnRip();
                isAnythingPicked = false;
                currentState = State.Fallen;
            }    

            if (!rb.IsAwake())
            {
                rb.WakeUp();
                rb.bodyType = RigidbodyType2D.Dynamic;
            }

            rb.AddForce(dragVector, ForceMode2D.Impulse);
        }
        else
        {
            transform.position = mousePos;
        }    
    }

    private void OnMouseUp()
    {
        isAnythingPicked = false;
    }
}