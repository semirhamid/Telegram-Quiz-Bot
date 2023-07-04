using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Filters;
using Telegram.Bot.Services;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace Telegram.Bot.Controllers;
[ApiController]
[Route("api/bot")]
public class BotController : ControllerBase
{
    [HttpPost]
    [ValidateTelegramBot]
    public async Task<IActionResult> Post(
        [FromBody] Update update,
        [FromServices] UpdateHandlers handleUpdateService,
        CancellationToken cancellationToken)
    {
        TelegramBotClient client = new TelegramBotClient("6183975424:AAGs2JxBKToZOlMr-0wucqBzob_UyH-aCsY");
        if (update != null && update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
        {
            await client.SendTextMessageAsync(update.Message.From.Id, "answer");
        }
        //await handleUpdateService.HandleUpdateAsync(update, cancellationToken);
        return Ok();
    }
}
