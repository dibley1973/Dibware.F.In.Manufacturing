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
    /// The distance along the X axis from the datum point.
    /// </summary>
    XPosition: int

    /// <summary>
    /// The distance along the Y axis from the datum point.
    /// </summary>
    YPosition: int
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
    /// <summary>
    /// The distance along the X axis from the datum point.
    /// </summary>
    XPosition: int

    /// <summary>
    /// The distance along the Y axis from the datum point.
    /// </summary>
    YPosition: int

    /// <summary>
    /// The distance along the Z axis from the datum point.
    /// </summary>
    ZPosition: int
}

/// <summary>
/// Represents a size in 2 Dimensions.
/// </summary>
type Size2D = {
    /// <summary>
    /// The length of the X-axis of an object.
    /// </summary>
    XLength: int

    /// <summary>
    /// The length of the Y-axis of an object.
    /// </summary>
    YLength: int
}

/// <summary>
/// Represents a size in 3 Dimensions.
/// </summary>
type Size3D = {
    /// <summary>
    /// The length of the X-axis of an object.
    /// </summary>
    XLength: int

    /// <summary>
    /// The length of the Y-axis of an object.
    /// </summary>
    YLength: int

    /// <summary>
    /// The length of the Z-axis of an object.
    /// </summary>
    ZLength: int
}