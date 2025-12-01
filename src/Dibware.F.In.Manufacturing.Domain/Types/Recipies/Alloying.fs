namespace Dibware.F.In.Manufacturing.Domain.Types.Recipies.Metals

open Dibware.F.In.Manufacturing.Domain.Types.Materials
open Dibware.F.In.Manufacturing.Domain.Types.Manufacturing
open Dibware.F.In.Manufacturing.Domain.Types.Mining

/// <summary>
/// Represents alloying operations in manufacturing.
module Alloying =
    let aluminaPowder = Powder.AluminaPowder |> RefinedPowder |> Refined
    let aluminiumIngot = AlluminiumIngot |> RefinedIngot |> Refined
    let causticSoda = Chemical.CausticSoda |> SynthesizedChemical |> Chemical
    let coal = Ore.Coal |> RawOre |> Raw
    let ironIngot = IronIngot |> RefinedIngot |> Refined
    let steelIngot = SteelIngot |> RefinedIngot |> Refined

    /// <summary>
    /// The recipe to make steel from iron ingots and coal.
    /// Takes 2 iron ingots and 1 coal to produce 1 steel ingot in 5 seconds.
    /// </summary>
    let steelRecipe : Recipe = {
        Input = MaterialList [ (coal, 1); (ironIngot , 2) ]
        Output = MaterialList [ (steelIngot, 1) ]
        TimeInSeconds = 5.0 // seconds
    }

    /// <summary>
    /// The recipe to make aluminium ingots from alumina powder and caustic soda.
    /// Takes 3 alumina powder and 1 caustic soda to produce 1 aluminium ingot in 4 seconds.
    /// </summary>
    let aluminiumRecipe : Recipe = {
        Input = MaterialList [ (aluminaPowder, 3); (causticSoda, 1) ]
        Output = MaterialList [ (aluminiumIngot, 1) ]
        TimeInSeconds = 4.0 // seconds
    }