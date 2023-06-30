using UnityEngine;
using Photon.Pun;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] PhotonView photonView;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = horizontal * Vector3.right + vertical * Vector3.up;

        _rb.velocity = _speed * Time.deltaTime * direction;
    }

    private void FixedUpdate()
    {
        if(photonView.IsMine)
            Movement();
    }
}
