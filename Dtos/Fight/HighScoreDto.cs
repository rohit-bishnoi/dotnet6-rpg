using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Dtos.Fight;

public class HighScoreDto
{
    public int Id { get; set; }
    public String Name { get; set; } =string.Empty;
    public int Fights { get; set; }
    public int Victorires { get; set; }
    public int Defeats { get; set; }
}
