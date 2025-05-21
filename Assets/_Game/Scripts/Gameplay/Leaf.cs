using UnityEngine;

public class Leaf : Tomato
{
    protected override void Start()
    {
        base.Start();
        PolygonCollider2D collider = gameObject.GetComponent<PolygonCollider2D>();
        collider.isTrigger = true;
        isTomato = false;
    }
}
