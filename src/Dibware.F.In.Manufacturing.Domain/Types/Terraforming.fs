namespace Dibware.F.In.Manufacturing.Domain.Types.Terraforming

open Dibware.F.In.Manufacturing.Domain.Types.Mining

/// <summary>
/// Describes a game area with length and width dimensions.
/// </summary>
type GameArea = {
    //Length: int
    //Width: int
    Grid: Rock[,]
}