namespace Dibware.F.In.Manufacturing.Domain.Generators.Terraforming

open Dibware.F.In.Manufacturing.Domain.Types.Terraforming
open Dibware.F.In.Manufacturing.Domain.Types.Mining

module Terraforming =
    /// <summary>
    /// A function that simulates terraforming a piece of land.
    /// </summary>
    let public terraformLand (length: int, width : int) : GameArea =
        let grid = Array2D.create length width IronImpregnatedRock
        { Grid = grid }
        //sprintf "The %s has been successfully terraformed." landType