namespace Dibware.F.In.Manufacturing.Domain.Behaviours.Operations

open Dibware.F.In.Manufacturing.Domain.Types.Materials
open Dibware.F.In.Manufacturing.Domain.Types.Manufacturing
open Dibware.F.In.Manufacturing.Domain.Types.ProcessingPlants

/// <summary>
/// Represents alloying operations in manufacturing.
/// </summary>
module Alloying =
    let steelIngot = SteelIngot |> RefinedIngot |> Refined

    /// <summary>
    /// Function to make steel using a steel mill, a recipe, and a material list.
    /// </summary>
    let tryMakeSteel steelMill (recipe: Recipe) (materialList: MaterialList): Material option =
        match steelMill with
        | SteelMill ->
            match recipe with
            | steelRecipe -> 
                // Check if the materialList contains the required input materials in the recipe
                let hasRequiredMaterials =
                    steelRecipe.Input
                    |> Map.forall (fun material quantity ->
                        match Map.tryFind material materialList with
                        | Some availableQuantity -> availableQuantity >= quantity
                        | None -> false)
                if hasRequiredMaterials then
                    steelIngot |> Some
                else
                    None
            | _ -> None
        | _ -> None



