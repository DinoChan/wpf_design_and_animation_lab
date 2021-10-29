using WpfDesignAndAnimationLab.Demos.FancyTexts;
using WpfDesignAndAnimationLab.Demos.OutlinedText;
using WpfDesignAndAnimationLab.Demos.TextShapes;

namespace WpfDesignAndAnimationLab.Infrastructure
{
    public class ExampleDefinitions
    {
        public static ExampleDefinition[] Definitions { get; } = {
             new ExampleDefinition("Outlined Text",null,
                new ExampleDefinitionItem("Demo1",typeof(Demo1Page)),
                new ExampleDefinitionItem("Demo2",typeof(Demo2Page)),
                new ExampleDefinitionItem("Demo3",typeof(Demo3Page)),
                new ExampleDefinitionItem("Demo4",typeof(Demo4Page)),
                new ExampleDefinitionItem("Demo5",typeof(Demo5Page)),
                new ExampleDefinitionItem("Demo6",typeof(Demo6Page)),
                new ExampleDefinitionItem("Demo7",typeof(Demo7Page)),
                new ExampleDefinitionItem("Demo8",typeof(Demo8Page))
              ),

            new ExampleDefinition("Fancy Text",null,typeof(FancyTextDemoPage)),
            new ExampleDefinition("TextShape",null,
                new ExampleDefinitionItem("Demo1",typeof(TextShapeDemo1Page)), 
                new ExampleDefinitionItem("StrokeDashOffset ",typeof(TextShapeDemo2Page))),
        };
    }
}
