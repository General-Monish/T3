using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private int penalty = 3; // Penalty in seconds
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.ApplyPenalty(penalty);
        }
    }
}
