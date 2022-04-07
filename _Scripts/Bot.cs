using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        gameObject.transform.Translate(0, 0, _speed * Time.deltaTime * -1);
    }
}
