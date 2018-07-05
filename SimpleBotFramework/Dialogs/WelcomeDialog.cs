using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace SimpleBotFramework.Dialogs
{
    [Serializable]
    public class WelcomeDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(PerformActionAsync);
            return Task.CompletedTask;
        }

        private async Task PerformActionAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            if (activity.Text.Equals("Hello"))
                await context.PostAsync("Welcome to bot Applicattion");
            else if (activity.Text.Equals("How are you?"))
                await context.PostAsync("I'm fine. Thanks for asking");
            else 
                await context.PostAsync("I am unable to understand you.");
        }
    }
}