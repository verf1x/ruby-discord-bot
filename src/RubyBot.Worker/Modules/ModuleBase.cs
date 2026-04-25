using Discord.Interactions;
using Discord.WebSocket;
using RubyBot.Contracts.Discord;

namespace RubyBot.Worker.Modules;

public class ModuleBase : InteractionModuleBase<SocketInteractionContext>
{
    protected DiscordExecutionContext CreateExecutionContext()
    {
        var guildUser = (SocketGuildUser)Context.User;

        return new DiscordExecutionContext(
            GuildId: Context.Guild.Id,
            ChannelId: Context.Channel.Id,
            UserId: Context.User.Id,
            VoiceChannelId: guildUser.VoiceChannel?.Id,
            RoleIds: guildUser.Roles.Select(role => role.Id).ToArray());
    }
}