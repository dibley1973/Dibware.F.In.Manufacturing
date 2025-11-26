namespace Dibware.F.In.Manufacturing.Domain.Types.Measurements

/// <summary>
/// Represents a point in a 2D coordinate system.
/// </summary>
/// <remarks>
/// The coordinate system is defined with respect to a datum point (origin).
/// The datum point (0,0) is considered to be at back-left.
/// The X axis extends horizontally to the right, and the Y axis extends towards you.
/// </remarks>
type Coordinate2D = {
    /// <summary>
    /// the distance along the X axis from the datum point.
    /// </summary>
    X: int
    Y: int
}

/// <summary>
/// Represents a point in a 3D coordinate system.
/// </summary>
/// <remarks>
/// The coordinate system is defined with respect to a datum point (origin).
/// The datum point (0,0,0) is considered to be at back-left-top.
/// The X axis extends horizontally to the right, and the Y axis extends towards you.
/// The Z axis extends downwards, into the world.
/// </remarks>
type Coordinate3D = {
    X: int
    Y: int
    Z: int
}

/// <summary>
/// Represents a size in 2 Dimensions.
/// </summary>
type Size2D = {
    /// <summary>
    /// The length of the X-axis of an object.
    /// </summary>
    X: int

    /// <summary>
    /// The length of the Y-axis of an object.
    /// </summary>
    Y: int
}

type Size3D = {
    X: int
    Y: int
    Z: int
}