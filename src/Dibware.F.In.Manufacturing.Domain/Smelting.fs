namespace Dibware.F.In.Manufacturing.Domain.Plants

open Dibware.F.In.Manufacturing.Domain.Data

/// <summary>
/// Describes operations related to smelting plants.
/// </summary>
module Smelting =

    /// <summary>
    /// Gets the smelting plant for a given ore type.
    /// </summary>
    let public getSmeltingPlantForOre (oreType: Ore) : SmeltingPlant option =
        match oreType with
        | Ore.IronOre -> IronOreSmelter |> Some
        | _ -> None 

    /// <summary>
    /// Gets the smelting plant for Iron Ore.
    /// </summary>
    let ironOreSmeltingPlant = getSmeltingPlantForOre Ore.IronOre

    /// <summary>
    /// A function that tries to smelt the specified ore using the specified smelting plant.
    /// </summary>
    let public tryToSmeltOre (plant: SmeltingPlant) (rawMaterial: Ore) : ProcessedMaterial option =
        match plant, rawMaterial with
        | IronOreSmelter, IronOre -> Iron { Name = "Iron Ingot" } |> Some
        | _ -> None

    /// <summary>
    /// A function that tries to smelt Iron Ore using the Iron Ore Smelter.
    /// </summary>
    let tryToSmelIronOre = tryToSmeltOre IronOreSmelter 

    /// <summary>
    /// Iron Ingot obtained by smelting Iron Ore.
    /// </summary>
    let ironOreIngot = tryToSmelIronOre IronOre
