using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint mediumTurret;
    public TurretBlueprint heavyTurret;

    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    
    public void SelectMediumTurret()
    {
        Debug.Log("Medium turret selected");
        buildManager.SelectTurretToBuild(mediumTurret);
    }

    public void SelectHeavyTurret()
    {
        Debug.Log("Heavy turret selected");
        buildManager.SelectTurretToBuild(heavyTurret);
    }


}