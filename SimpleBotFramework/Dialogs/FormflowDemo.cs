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
        [Describe("Intel Core I3")]
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

        [Optional]
        [Describe(description:"Company", title:"Laptop Brand", subTitle:"There are several other brand present for sales but not this one")]
        public Laptopbrand? Laptopbrand;
        public OperatingSystem? OperatingSystem;
        public Processor? Processor;

        [Describe("touch screen device !")]
        [Prompt("Do you prefer {&}? {||}")]
        public bool? RequiresTouch;

        [Numeric(2,12)]
        [Describe(description:"Minimum Capacity of RAM")]
        public int? MinimumRamSize;

        [Pattern(@"^[206]\d{9}$")]
        public string MobileNumberAttribute;

        public static IForm<Formflowdemo> GetForm()
        {
            return new FormBuilder<Formflowdemo>()
                .Message("welcome to Laptop suggestion Bot")
                .Field(nameof(MobileNumberAttribute))
                .AddRemainingFields()
                .Build();
        }
   
    }

}