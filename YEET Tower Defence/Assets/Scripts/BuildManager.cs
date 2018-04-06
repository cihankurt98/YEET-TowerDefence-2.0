using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance; // only one buildmanager for the whole scene //singleton pattern

    public GameObject standardTurretPrefab;
    public GameObject mediumTurretPrefab;
    public GameObject heavyTurretPrefab;

    private TurretBlueprint turretToBuild;


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple BuildManagers in scene");
            return;
        }
        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney
    {
        get
        {
            if (TurnManager.GetPlayerWithTurn() != null)
            {
                return TurnManager.GetPlayerWithTurn().Money >= turretToBuild.cost;
            }
            else
            {
                return false;
            }
        }
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void  BuildTurretOn (Node node)
    {
        if (TurnManager.GetPlayerWithTurn().Money < turretToBuild.cost)
        {
            Debug.Log("not enough money");
            return;
        }

        TurnManager.GetPlayerWithTurn().Money -= turretToBuild.cost;

        GameObject turret =  Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.currentTurret = turret;

        turret.GetComponent<Turret>().owner = TurnManager.GetPlayerWithTurn();

        Debug.Log("Turret build! Money left: " + TurnManager.GetPlayerWithTurn().Money);
    }
}
