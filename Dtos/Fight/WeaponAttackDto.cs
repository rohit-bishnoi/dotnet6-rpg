using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Dtos.Fight;

public class WeaponAttackDto
{
    public int AttackerID { get; set; }
    public int OpponentId { get; set; }
}
