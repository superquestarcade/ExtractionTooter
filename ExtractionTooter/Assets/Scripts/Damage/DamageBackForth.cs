using UnityEngine;

namespace Damage
{
	public class DamageBackForth : MonoBehaviourPlus
    {
        [SerializeField] private Vector2 pointA, pointB;
        [SerializeField] private float speed = 2f;
        private Vector2 targetPos;
        private Vector3 origin;
        private bool hasTarget = false;
        private System.Random rng;
        private bool forwards;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rng = new System.Random(gameObject.GetHashCode());
            origin = transform.position;
        }
    
        // Update is called once per frame
        void Update()
        {
            if (hasTarget) MoveToTarget();
            else SetNewTarget();
        }
    
        private void SetNewTarget()
        {
            targetPos = GetNewTarget();
            hasTarget = true;
        }

        private Vector2 GetNewTarget()
        {
            forwards = !forwards;
            return origin + (Vector3) (forwards ? pointA : pointB);
        }

        private void MoveToTarget()
        {
            var direction = (Vector3) targetPos - transform.position;
            var distance = direction.magnitude;
            transform.position += direction.normalized * Mathf.Clamp((speed * Time.deltaTime),0,distance);
            if (((Vector3) targetPos - transform.position).magnitude < 0.01f) hasTarget = false;
        }
    
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + (Vector3) pointA, 0.2f);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position + (Vector3) pointB, 0.2f);
        }
	}
}