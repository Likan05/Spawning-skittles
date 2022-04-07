using UnityEngine;
using UnityEngine.Events;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private UnityEvent _pressed;

    private float _startCordinateY;

    private void Start()
    {
        _startCordinateY = transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        float howLongY = 0.5f;

        if (other.TryGetComponent<Bot>(out Bot bot))
        {
            _pressed?.Invoke();            
            transform.position = new Vector3(transform.position.x, (howLongY - transform.position.y), transform.position.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Bot>(out Bot bot))
        {
            transform.position = new Vector3(transform.position.x, _startCordinateY, transform.position.z);
        }
    }
}
