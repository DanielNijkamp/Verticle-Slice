using UnityEngine;

public class OpenClose : MonoBehaviour
{
    private bool isClosed = false;
    private SpriteRenderer _sp;
    public Sprite[] sp;
    private Rigidbody2D _rb;

    private void Start()
    {
        _sp = this.gameObject.GetComponent<SpriteRenderer>();
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            if (_sp == null || _rb == null)
            {
                _sp = this.gameObject.GetComponent<SpriteRenderer>();
                _rb = this.gameObject.GetComponent<Rigidbody2D>();
            }

            if (isClosed == false)
            {
                isClosed = true;
                _sp.sprite = sp[0];
                _rb.useFullKinematicContacts = false;
                return;
            }
            if (isClosed == true)
            {
                isClosed = false;
                _sp.sprite = sp[1];
                _rb.useFullKinematicContacts = true;
                return;
            }
        }
    }
}