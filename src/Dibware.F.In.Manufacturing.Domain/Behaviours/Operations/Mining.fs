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
    /// <returns>
    /// The rock at the specified location, or None if no rock is present.
    /// </returns>
    let public getRockAtLocation (location: Coordinate2D, world: World2D) : Rock option =
        let rockAtLocation = world.Map.[location.XPosition, location.YPosition]
        
        match rockAtLocation with
        | Rock.VoidOfAnyRock -> None
        | _ -> (rockAtLocation |> Some)

    /// <summary>
    /// Gets the rock at a given location in the world.
    /// </summary>
    /// <param name="location">The 2D location to check for rock.</param>
    /// <param name="world">The 2D world containing the rock map.</param>
    /// <returns>The rock at the specified location, or None if no rock is present.</returns>
    let public mineLocation (location: Coordinate2D, world: World2D, rockMiner) : Rock option =
        //let rockAtLocation = world.Map.[location.X, location.Y]
        let rockAtLocation = rockMiner(location, world)
        
        match rockAtLocation with
        | Rock.Useless -> None
        | Rock.VoidOfAnyRock -> None
        | _ -> Some rockAtLocation
