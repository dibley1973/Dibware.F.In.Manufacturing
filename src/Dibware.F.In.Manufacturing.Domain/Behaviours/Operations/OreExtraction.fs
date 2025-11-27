namespace Dibware.F.In.Manufacturing.Domain.Behaviours.Operations

open Dibware.F.In.Manufacturing.Domain.Types.Mining

/// <summary>
/// Describes operations related to mining plants.
/// </summary>
module OreExtraction =
    /// <summary>
    /// Processes the supplied rock to extract ore, if any.
    /// </summary>
    /// <param name="rock">The rock to be proessed.</param>
    /// <returns>The extracted ore, or None if no ore is present.</returns>
    let public ExtractOre (rock: Rock) : Ore option =
        match rock with
        | Rock.IronImpregnatedRock -> Ore.IronOre |> Some
        | Rock.CoalImpregnatedRock -> Ore.Coal |> Some
        | Rock.CopperImpregnatedRock -> Ore.CopperOre |> Some
        | Rock.Useless -> None
        | _ -> None
