namespace Dibware.F.In.Manufacturing.Domain.Types.Manufacturing

open Dibware.F.In.Manufacturing.Domain.Types.Materials

/// <summary>
/// Represents a list of materials along with their quantities.
/// </summary>
type MaterialList = Map<Material, int>

/// <summary>
/// Describes a manufacturing recipe, defining the input materials,
/// output materials, and time required for the manufacturing process.
/// </summary>
type Recipe = {
    Input: MaterialList // Map<Material, int>
    Output: MaterialList // Map<Material, int>
    TimeInSeconds: float
}

type RecipeElement = {
    Material: Material
    Quantity: int
}
