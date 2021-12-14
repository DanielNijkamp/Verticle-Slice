using UnityEngine;

public class Placement : MonoBehaviour
{
    private buildmanager BM;

    public Color hovercolor;
    [HideInInspector] public Color startcolor;
    [HideInInspector] public SpriteRenderer rend;
    private GameObject turret;

    public void Start()
    {
        BM = GameObject.FindWithTag("GM").GetComponent<buildmanager>();

        rend = GetComponent<SpriteRenderer>();
        startcolor = rend.material.color;
    }

    public void OnMouseDown()
    {
        if (BM.instance.Getturrettobuild() == null)
        {
            return;
        }
        if (turret != null)
        {
            return;
        }
        GameObject TurretToBuild = BM.instance.Getturrettobuild();
        turret = (GameObject)Instantiate(TurretToBuild, transform.position, transform.rotation);
    }

    public void OnMouseEnter()
    {
        rend.material.color = hovercolor;
    }

    public void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}