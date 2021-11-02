using WpfDesignAndAnimationLab.Demos.FancyTexts;
using WpfDesignAndAnimationLab.Demos.InnerShadows;
using WpfDesignAndAnimationLab.Demos.OutlinedText;
using WpfDesignAndAnimationLab.Demos.RadialProgresses;
using WpfDesignAndAnimationLab.Demos.TextShapes;

namespace WpfDesignAndAnimationLab.Infrastructure
{
    public class ExampleDefinitions
    {
        public static ExampleDefinition[] Definitions { get; } = {
             new ExampleDefinition("Outlined Text",null,
                new ExampleDefinitionItem("Main",typeof(Demo1Page)),
                new ExampleDefinitionItem("Buttons",typeof(OutlinedTextButtonDemo)),
                new ExampleDefinitionItem("Demo5",typeof(Demo5Page)),
                new ExampleDefinitionItem("Demo6",typeof(Demo6Page)),
                new ExampleDefinitionItem("Demo7",typeof(Demo7Page)),
                new ExampleDefinitionItem("Demo8",typeof(Demo8Page)),
                new ExampleDefinitionItem("Demo9",typeof(Demo9Page))
              ),

            new ExampleDefinition("Fancy Text",null,typeof(FancyTextDemoPage)),
            new ExampleDefinition("TextShape",null,
                new ExampleDefinitionItem("Main",typeof(TextShapeDemo1Page)), 
                new ExampleDefinitionItem("StrokeDashOffset ",typeof(TextShapeDemo2Page))),
              new ExampleDefinition("InnerShadow",null,typeof(InnerShadow)),
              new ExampleDefinition("RadialProgressBar",null,typeof(RadialProgressDemo)),
        };
    }
}
