using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField]
    private LaserGun[] laserGuns;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            foreach (LaserGun gun in laserGuns)
            {
                gun.Fire();
            }
        }
    }
}