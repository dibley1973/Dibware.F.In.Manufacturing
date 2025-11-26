namespace Dibware.F.In.Manufacturing.Domain.Behaviours.Operations

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
        | Ore.IronOre -> IronOreMine |> Some
        | Ore.Coal -> CoalMine |> Some
        | Ore.CopperOre -> CopperMine |> Some
        //| Ore.AluminumOre -> Some //"Aluminum Ore Mine"
        //| Ore.GoldOre -> Some //"Gold Ore Mine"
        //| Ore.SilverOre -> Some //"Silver Ore Mine"
        | _ -> None

    /// <summary>
    /// Gets the mining plant for Iron Ore.
    /// </summary>
    let getIronOreMine() = getMiningPlantForOre Ore.IronOre