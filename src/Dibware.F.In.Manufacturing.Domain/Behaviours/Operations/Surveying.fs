namespace Dibware.F.In.Manufacturing.Domain.Behaviours.Operations

open Dibware.F.In.Manufacturing.Domain.Types.Mining
open Dibware.F.In.Manufacturing.Domain.Types.Measurements
open Dibware.F.In.Manufacturing.Domain.Types.Terraforming

/// <summary>
/// Describes operations related to surveying locations in the game world.
/// </summary>
module Surveying =
    /// <summary>
    /// A function that performs a surveying operation to identify 
    /// rock types in the game world.
    /// </summary>
    /// <param name="location">The 2D location to check for rock.</param>
    /// <param name="world">The 2D world containing the rock map.</param>
    /// <returns>
    /// The rock at the specified location, or None if no rock is present.
    /// </returns>
    let public surveyLocation (location: Coordinate2D, world: World2D) : Rock option =
        let rockAtLocation = world.Map.[location.XPosition, location.YPosition]
        
        match rockAtLocation with
        | Rock.VoidOfAnyRock -> None
        | _ -> (rockAtLocation |> Some)
