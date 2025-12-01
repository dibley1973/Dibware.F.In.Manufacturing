namespace Dibware.F.In.Manufacturing.Domain.Types.Recipies.Metals

open Dibware.F.In.Manufacturing.Domain.Types.Materials
open Dibware.F.In.Manufacturing.Domain.Types.Manufacturing
open Dibware.F.In.Manufacturing.Domain.Types.Mining

/// <summary>
/// Represents alloying operations in manufacturing.
module Alloying =
    //let aluminiumIngot = AlluminiumIngot |> RefinedIngot |> Refined
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

    /// <summary>
    /// The recipe to make aluminium ingots from alumina powder and caustic soda.
    /// Takes 3 alumina powder and 1 caustic soda to produce 1 aluminium ingot in 4 seconds.
    /// </summary>
    let aluminiumRecipe : Recipe = {
        Input = Map.ofList<Material, int> [ (Powder.AluminaPowder |> RefinedPowder |> Refined, 3); (Chemical.CausticSoda |> SynthesizedChemical |> Chemical, 1) ]
        Output = Map.ofList<Material, int> [ (AlluminiumIngot |> RefinedIngot |> Refined, 1) ]
        TimeInSeconds = 4.0 // seconds
    }