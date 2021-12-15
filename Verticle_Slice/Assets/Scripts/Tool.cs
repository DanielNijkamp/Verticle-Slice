using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public Breakable_Prefab BP;
    public LayerMask _layer;
    public float toolrange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 100f, _layer);
            if (hit.collider != null & hit.transform.gameObject.GetComponent<Breakable_Prefab>() != null && Vector3.Distance(this.transform.position,hit.transform.position) < toolrange)
            {
                this.BP = hit.transform.gameObject.GetComponent<Breakable_Prefab>();
                GetObjectType();
            }

        }
    }
    public void GetObjectType()
    {
        if (BP.isHoe)
        {
            BP.TakeDamage(1);
        }
        else if (BP.isAxe)
        {
            BP.TakeDamage(1);
        }
        else if (BP.isPickaxe)
        {
            BP.TakeDamage(1);
        }
        else if (BP.isScythe)
        {
            BP.TakeDamage(1);
        }
    }
}
