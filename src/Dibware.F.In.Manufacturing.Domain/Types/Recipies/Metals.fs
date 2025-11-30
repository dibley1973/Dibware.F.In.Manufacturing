namespace Dibware.F.In.Manufacturing.Domain.Types.Recipies.Metals

open Dibware.F.In.Manufacturing.Domain.Types.Materials
open Dibware.F.In.Manufacturing.Domain.Types.Manufacturing
open Dibware.F.In.Manufacturing.Domain.Types.Mining

/// <summary>
/// Represents alloying operations in manufacturing.
module Alloying =
    let ironIngot = IronIngot |> RefinedIngot |> Refined
    let coal = Ore.Coal |> RawOre |> Raw
    let steelIngot = SteelIngot |> RefinedIngot |> Refined

    /// <summary>
    /// The recipe to make steel from iron ingots and coal.
    /// Takes 2 iron ingots and 1 coal to produce 1 steel ingot in 5 seconds.
    /// </summary>
    let steelRecipe : Recipe = {
        Input = Map.ofList<Material, int> [ (coal, 1); (ironIngot , 2) ]
        Output = Map.ofList<Material, int> [ (steelIngot, 1) ]
        TimeInSeconds = 5.0 // seconds
    }