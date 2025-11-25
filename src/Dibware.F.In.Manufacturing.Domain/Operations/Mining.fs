namespace Dibware.F.In.Manufacturing.Domain.Operations

open Dibware.F.In.Manufacturing.Domain.Types.Mining

/// <summary>
/// Describes operations related to mining plants.
/// </summary>
module Mining =
    /// <summary>
    /// Gets the mining plant for a given ore type.
    /// </summary>
    let public getMiningPlantForOre (oreType: Ore) : Mine option =
        match oreType with
        | Ore.IronOre -> Some IronOreMine
        | Ore.Coal -> Some CoalMine
        | Ore.CopperOre -> Some CopperMine
        //| Ore.AluminumOre -> Some //"Aluminum Ore Mine"
        //| Ore.GoldOre -> Some //"Gold Ore Mine"
        //| Ore.SilverOre -> Some //"Silver Ore Mine"
        | _ -> None