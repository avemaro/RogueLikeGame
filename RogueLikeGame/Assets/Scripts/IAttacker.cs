using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker {
    bool Attack();
    bool IsAttacked(IAttacker attacker);
}