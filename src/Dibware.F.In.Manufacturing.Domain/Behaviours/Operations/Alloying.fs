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
    let tryMakeSteelIngot millingPlant (recipe: Recipe) (materialList: MaterialList): Material option =
        match millingPlant with
        | SteelMill ->
            match recipe with
            | steelRecipe -> // TODO: correct this to match correct Recipe only
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
                    None        // Incorrect material list
            | _ -> None         // Wrong recipe for steel production
        | _ -> None             // Wrong plant for steel production



