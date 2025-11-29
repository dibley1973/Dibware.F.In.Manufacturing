namespace Dibware.F.In.Manufacturing.Domain.Types.Manufacturing

open Dibware.F.In.Manufacturing.Domain.Types.Materials

/// <summary>
/// Describes a manufacturing recipe, defining the input materials,
/// output materials, and time required for the manufacturing process.
/// </summary>
type Recipe = {
    Input: Map<Material, int>
    Output: Map<Material, int>
    Time: float
}

type RecipeElement = {
    Material: Material
    Quantity: int
}
