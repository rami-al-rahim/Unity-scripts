using UnityEngine;

[HelpURL("https://www.youtube.com/watch?v=Sao0j1XNcvM")]
public class CamFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;
    private Vector3 velocity;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Vector3 movePos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePos, ref velocity, damping);
    }
}
