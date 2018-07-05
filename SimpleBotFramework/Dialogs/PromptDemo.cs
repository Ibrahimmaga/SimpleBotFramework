using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Connector;

namespace SimpleBotFramework.Dialogs
{
    [Serializable]
    public class PromptDemo : IDialog<object>
    {
        private string name;
        private long age;

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Thank for using Bot application for registration. <br> Fill the below details to complete registration");
            context.Wait(GetNameAsync);
        }

        private Task GetNameAsync(IDialogContext context, IAwaitable<IMessageActivity> activity)
        {
            PromptDialog.Text(
                context: context,
                resume: ResumeGetName,
                prompt: "Please enter your name",
                retry: "sorry I didn't get that. Please try again"
                );
            return Task.CompletedTask;
        }

        private async Task ResumeGetName(IDialogContext context, IAwaitable<string> result)
        {
            name = await result;
            PromptDialog.Number(
                context: context,
                resume: ResumeGetAge,
                prompt: $"{name }, Please enter your age",
                retry: "sorry I didn't get that. Please try again",
                attempts: 3,
                max: 50,
                min: 10

                );
           
        }

        private async Task ResumeGetAge(IDialogContext context, IAwaitable<long> result)
        {
            age = await result;
            PromptDialog.Confirm(
                context: context,
                resume: ResumeConfirm,
                prompt: $"Your name is *{name }*, and you age is *{age}* Right?",
                retry: "sorry I didn't get that. Please try again"
                //options: new string[] { "Yeah", "Nope" },
                //promptStyle: PromptStyle.PerLine
                );

        }

        private async Task ResumeConfirm(IDialogContext context, IAwaitable<bool> result)
        {
           if(await result)
            {
                await context.PostAsync($"You are registered succesfully. <br/> your name is **{name}**, and your age is **{age}**.");
            }
            else
            {
                await context.PostAsync("Are you sure");
                context.Done(string.Empty);
            }

        }
    }

}