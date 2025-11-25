namespace Dibware.F.In.Manufacturing.Domain.Operations

open Dibware.F.In.Manufacturing.Domain.Data

/// <summary>
/// Describes operations related to mining plants.
/// </summary>
module Mining =
    /// <summary>
    /// Gets the mining plant for a given ore type.
    /// </summary>
    let public getMiningPlantForOre (oreType: Ore) : string option =
        match oreType with
        | Ore.IronOre -> Some "Iron Ore Mine"
        | Ore.CopperOre -> Some "Copper Ore Mine"
        | Ore.AluminumOre -> Some "Aluminum Ore Mine"
        | Ore.GoldOre -> Some "Gold Ore Mine"
        | Ore.SilverOre -> Some "Silver Ore Mine"