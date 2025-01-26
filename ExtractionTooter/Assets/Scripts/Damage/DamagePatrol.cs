using System;
using UnityEngine;

public class DamagePatrol : MonoBehaviourPlus
{
    [SerializeField] private float range = 5f;
    [SerializeField] private float speed = 2f;
    private Vector2 origin;
    private Vector2 targetPos;
    private bool hasTarget = false;
    private System.Random rng;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        origin = transform.position;
        rng = new System.Random(gameObject.GetHashCode());
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTarget) MoveToTarget();
        else SetNewTarget();
    }

    private void OnValidate()
    {
        origin = transform.position;
    }

    private void SetNewTarget()
    {
        targetPos = GetRandomPointInRange(origin, range);
        hasTarget = true;
    }

    private void MoveToTarget()
    {
        var direction = (Vector3) targetPos - transform.position;
        var distance = direction.magnitude;
        transform.position += direction.normalized * Mathf.Clamp((speed * Time.deltaTime),0,distance);
        if (((Vector3) targetPos - transform.position).magnitude < 0.01f) hasTarget = false;
    }

    private Vector2 GetRandomPointInRange(Vector2 _origin, float _radius)
    {
        // Generate a random angle in radians
        var angle = (float) rng.NextDouble() * (Mathf.PI * 2);
        
        // Generate a random radius with even distribution
        var radius = Mathf.Sqrt((float) rng.NextDouble()) * _radius;

        // Calculate the x and y coordinates
        var x = _origin.x + radius * Mathf.Cos(angle);
        var y = _origin.y + radius * Mathf.Sin(angle);

        return new Vector2(x, y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin, range);
    }
}
