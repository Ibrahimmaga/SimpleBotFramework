using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;


namespace SimpleBotFramework.Dialogs
{
   public enum Laptopbrand
    {
        HP, Lenovo, Acer, Microsoft, Mac, Dell
    }

    public enum LaptopType
    {
        Laptop, gaming, Ultrabook, Notebook
    }
    public enum Processor
    {
        IntelI3, IntelI5, IntelI7, IntelCore, AMD
    }
    public enum OperatingSystem
    {
        Windows7, windows8, windows10, linux
    }

    [Serializable]
    public class Formflowdemo
    {
        public LaptopType? LaptopType;
        public Laptopbrand? Laptpbrand;
        public OperatingSystem? OperatingSystem;
        public Processor? Processor;

        public bool? RequiresTouch;
        public int? MinimumRamSize;

        public static IForm<Formflowdemo> GetForm()
        {
            return new FormBuilder<Formflowdemo>()
                .Message("welcome to Laptop suggestion Bot")
                .Build();
        }
   
    }

}