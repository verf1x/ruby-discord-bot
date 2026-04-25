namespace RubyBot.Contracts.Discord;

public sealed record DiscordExecutionContext(
    ulong GuildId,
    ulong ChannelId,
    ulong UserId,
    ulong? VoiceChannelId,
    IReadOnlyCollection<ulong> RoleIds);