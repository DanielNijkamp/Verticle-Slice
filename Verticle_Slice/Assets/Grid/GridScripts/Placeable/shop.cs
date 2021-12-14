using UnityEngine;

public class shop : MonoBehaviour
{
    protected buildmanager BM;
    protected Placement PS;

    [Header("If there's not enough money.")]
    [HideInInspector] public GameObject turret;

    public void Start()
    {
        PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        BM = GameObject.FindWithTag("GM").GetComponent<buildmanager>();
    }

    public void PlaceObject1()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        BM.SetTurretToBuild(BM.placeable[0]);
    }

    public void PlacaObject2()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        BM.SetTurretToBuild(BM.placeable[1]);
    }

    public void PlaceObject3()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        BM.SetTurretToBuild(BM.placeable[2]);
    }

    public void PlaceObject4()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        BM.SetTurretToBuild(BM.placeable[3]);
    }

    public void PlaceObject5()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        BM.SetTurretToBuild(BM.placeable[4]);
    }

    public void PlaceObject6()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        BM.SetTurretToBuild(BM.placeable[5]);
    }

    public void PlaceObject7()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        BM.SetTurretToBuild(BM.placeable[6]);
    }

    public void PlaceObject8()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        BM.SetTurretToBuild(BM.placeable[7]);
    }

    public void PlaceObject9()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        BM.SetTurretToBuild(BM.placeable[8]);
    }

    public void PlaceObject10()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        BM.SetTurretToBuild(BM.placeable[9]);
    }
}