using UnityEngine;

public class buildmanager : MonoBehaviour
{
    [HideInInspector] public buildmanager instance;

    protected buildmanager BM;
    protected shop SH;

    [Header("Placeable Objects.")]
    public GameObject[] placeable;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one buildmanager");
            return;
        }
        instance = this;
    }

    public void Start()
    {
        BM = GameObject.FindWithTag("GM").GetComponent<buildmanager>();
        SH = GameObject.FindWithTag("GM").GetComponent<shop>();
        for (int i = 0; i < placeable.Length; i++)
        {
            turrettobuild = placeable[i];
        }
    }

    private GameObject turrettobuild;

    public GameObject Getturrettobuild()
    {
        return turrettobuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turrettobuild = turret;
    }
}