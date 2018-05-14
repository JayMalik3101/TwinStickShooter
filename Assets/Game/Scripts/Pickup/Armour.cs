using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : Pickups {

    public override void PickupEffect(Collider other)
    {
        if (other.GetComponent<PlayerStats>())
            other.GetComponent<PlayerStats>().m_ArmourActive = true;
        base.PickupEffect(other);
    }
}
