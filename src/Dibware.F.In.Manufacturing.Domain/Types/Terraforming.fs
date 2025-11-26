namespace Dibware.F.In.Manufacturing.Domain.Types.Terraforming

open Dibware.F.In.Manufacturing.Domain.Types.Mining
open Dibware.F.In.Manufacturing.Domain.Types.Measurements

/// <summary>
/// Describes a 2 dimensional game area (World) with 2 dimensions, and a content of <see cref="Rock"/> items.
/// </summary>
type World2D = {
    ///  <summary>
    /// The dimensions of the world in X and Y axes.
    ///  </summary>
    Dimensions: Coordinate2D

    Map: Rock[,]
}

/// <summary>
/// Describes a 3 dimensional game area (World) with 3 dimensions, and a content of <see cref="Rock"/> items.
/// </summary>
type World3D = {
    ///  <summary>
    /// The dimensions of the world in X, Y and Z axes.
    ///  </summary>
    Dimensions: Coordinate3D
    Map: Rock[,,]
}