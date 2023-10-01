namespace Discord;

/// <summary>
///     Represents a partial sticker item received with a message.
/// </summary>
public interface IStickerItem : ISnowflakeEntity
{
    /// <summary>
    ///     The name of the sticker.
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     The format of the sticker.
    /// </summary>
    StickerFormatType Format { get; }
}