namespace Dibware.F.In.Manufacturing.Domain.Behaviours.Operations

open Dibware.F.In.Manufacturing.Domain.Types.Mining
open Dibware.F.In.Manufacturing.Domain.Types.Measurements
open Dibware.F.In.Manufacturing.Domain.Types.Terraforming

/// <summary>
/// Describes operations related to mining plants.
/// </summary>
module Mining =
    /// <summary>
    /// Gets the rock at a given location in the world.
    /// </summary>
    /// <param name="location">The 2D location to check for rock.</param>
    /// <param name="world">The 2D world containing the rock map.</param>
    /// <returns>The rock at the specified location, or None if no rock is present.</returns>
    let public MineLocation (location: Coordinate2D, world: World2D ) Rock option =
        let rockAtLocation = world.Map.[location.X, location.Y]
        match rockAtLocation with
        | Rock.Useless -> None
        | Rock.VoidOfAnyRock -> None
        | _ -> Some rockAtLocation

    /// <summary>
    /// Mines the given rock to extract ore, if any.
    /// </summary>
    /// <param name="rock">The rock to be mined.</param>
    /// <returns>The extracted ore, or None if no ore is present.</returns>
    let public MineRock (rock: Rock) : Ore option =
        match rock with
        | Rock.IronImpregnatedRock -> Ore.IronOre |> Some
        | Rock.CoalImpregnatedRock -> Ore.Coal |> Some
        | Rock.CopperImpregnatedRock -> Ore.CopperOre |> Some
        | Rock.Useless -> None
        | _ -> None

    ///// <summary>
    ///// Gets the mining plant for a given ore type.
    ///// </summary>
    //let public getMineForOre (oreType: Ore) : Mine option =
    //    match oreType with
    //    | Ore.IronOre -> IronOreMine |> Some
    //    | Ore.Coal -> CoalMine |> Some
    //    | Ore.CopperOre -> CopperMine |> Some
    //    //| Ore.AluminumOre -> Some //"Aluminum Ore Mine"
    //    //| Ore.GoldOre -> Some //"Gold Ore Mine"
    //    //| Ore.SilverOre -> Some //"Silver Ore Mine"
    //    | _ -> None

    ///// <summary>
    ///// Gets a mine for Iron Ore.
    ///// </summary>
    //let getIronOreMine() = getMineForOre Ore.IronOre

    ///// <summary>
    ///// Gets a mine for Coal.
    ///// </summary>
    //let getCoalMine() = getMineForOre Ore.Coal

    ///// <summary>
    ///// Gets a mine for Copper Ore.
    ///// </summary>
    //let getCopperOreMine() = getMineForOre Ore.CopperOre

    //let public MineRock (rock: Rock, mine: Mine) : Ore option =
    //    match rock, mine with
    //    | Rock.IronImpregnatedRock, Mine.IronOreMine -> Ore.IronOre |> Some
    //    | Rock.CoalimpregnatedRock -> Ore.Coal |> Some
    //    | Rock.CopperImpregnatedRock -> Ore.CopperOre |> Some
    //    | Rock.Shale -> None
