using WpfDesignAndAnimationLab.Demos.AnimateProgressRing;
using WpfDesignAndAnimationLab.Demos.ArcProgresses;
using WpfDesignAndAnimationLab.Demos.Buttons;
using WpfDesignAndAnimationLab.Demos.ColumnProgressBars;
using WpfDesignAndAnimationLab.Demos.Effects;
using WpfDesignAndAnimationLab.Demos.FancyTexts;
using WpfDesignAndAnimationLab.Demos.GlowEffects;
using WpfDesignAndAnimationLab.Demos.InnerShadows;
using WpfDesignAndAnimationLab.Demos.LongShadows;
using WpfDesignAndAnimationLab.Demos.Neuomorphism;
using WpfDesignAndAnimationLab.Demos.NintendoSwitchLoadings;
using WpfDesignAndAnimationLab.Demos.OutlinedText;
using WpfDesignAndAnimationLab.Demos.ProgressRings;
using WpfDesignAndAnimationLab.Demos.RainbowButtons;
using WpfDesignAndAnimationLab.Demos.RainbowTexts;
using WpfDesignAndAnimationLab.Demos.ScaleMarks;
using WpfDesignAndAnimationLab.Demos.Shapes;
using WpfDesignAndAnimationLab.Demos.TextAndShadows;
using WpfDesignAndAnimationLab.Demos.TextEffects;
using WpfDesignAndAnimationLab.Demos.TextShapes;
using WpfDesignAndAnimationLab.Demos.TextShimmers;
using WpfDesignAndAnimationLab.Demos.Transitions;
using WpfDesignAndAnimationLab.Demos.WaveProgressBars;
using WpfDesignAndAnimationLab.Demos.Waves;

namespace WpfDesignAndAnimationLab.Infrastructure;

public class ExampleDefinitions
{
    public static ExampleDefinition[] Definitions { get; } =
    {   new("Neuomorphism", null,
            new ExampleDefinitionItem("Neuomorphism Panel", typeof(NeuomorphismPanel)),
            new ExampleDefinitionItem("Button", typeof(NeuomorphismButtonDemo))
        ),
          new("ScaleMark", null,
            new ExampleDefinitionItem("ScaleMark", typeof(ScaleMarkDemo)),
            new ExampleDefinitionItem("Gauge Chart", typeof(ScaleMarkDemoUsingArcPanel))
        ),
        new("Outlined Text", null,
            new ExampleDefinitionItem("Main", typeof(Demo1Page)),
            new ExampleDefinitionItem("Buttons", typeof(OutlinedTextButtonDemo)),
            new ExampleDefinitionItem("Demo5", typeof(Demo5Page)),
            new ExampleDefinitionItem("Demo6", typeof(Demo6Page)),
            new ExampleDefinitionItem("Demo7", typeof(Demo7Page)),
            new ExampleDefinitionItem("Demo8", typeof(Demo8Page))
        ),
        new("Fancy Text", null, typeof(FancyTextDemoPage)), new("TextShape", null,
            new ExampleDefinitionItem("Main", typeof(TextShapeDemo1Page)),
            new ExampleDefinitionItem("StrokeDashOffset ", typeof(TextShapeDemo2Page)),
            new ExampleDefinitionItem("Demo3", typeof(TextShapeDemo3Page)),
            new ExampleDefinitionItem("VariableFont1", typeof(VariableFont1Page)),
            new ExampleDefinitionItem("VariableFont2", typeof(VariableFont2Page)),
            new ExampleDefinitionItem("VariableFont3", typeof(VariableFont3Page)),
            new ExampleDefinitionItem("VariableFont4", typeof(VariableFont4Page)),
            new ExampleDefinitionItem("VariableFont5", typeof(VariableFont5Page)),
            new ExampleDefinitionItem("VariableFont6", typeof(VariableFont6Page))
        ),
        new("InnerShadow", null,
            new ExampleDefinitionItem("InnerShadow", typeof(InnerShadowDemo)),
            new ExampleDefinitionItem("Variable Size", typeof(VariableSizeInnerShadowDemo))

            // new ExampleDefinitionItem("Path Inner Shadow",typeof(PathInnerShadowDemo))
        ),
        new("ArcProgressBar", null,
            new ExampleDefinitionItem("Basic", typeof(ArcProgressDemo)),
            new ExampleDefinitionItem("Design ", typeof(ArcProgressDesignDemo))),
        new("TextAndShadows", null,
            new ExampleDefinitionItem("Demo1", typeof(TextAndShadowDemo1)),
            new ExampleDefinitionItem("Demo2", typeof(TextAndShadowDemo2))
        ),
        new("RainbowText", null,
            new ExampleDefinitionItem("Basic", typeof(RainbowTextDemo1)),
            new ExampleDefinitionItem("Animation", typeof(RainbowTextWithAnimation)),
            new ExampleDefinitionItem("Wave", typeof(RainbowTextWithWave)),
            new ExampleDefinitionItem("Random", typeof(RainbowTextWithRandom))),
        new("ColumnProgressBar", null,
            new ExampleDefinitionItem("ColumnProgressBar", typeof(ColumnProgressBarDemo))
        ),
        new("RainbowButton", null,
            new ExampleDefinitionItem("Apple", typeof(RainbowAppleButton)),
            new ExampleDefinitionItem("With Glow", typeof(RainbowAppleButtonWithGlow))
        ),
        new("Nintendo Switch", null,
            new ExampleDefinitionItem("Loading", typeof(NintendoSwitchLoading)),
            new ExampleDefinitionItem("eShop", typeof(NintendoEShopLoading)),
            new ExampleDefinitionItem("eShop Using Effect", typeof(NintendoEShopLoadingUsingEffect))
        ),
        new("TextEffect", null,
            new ExampleDefinitionItem("Basic", typeof(TextEffectsBasicDemo))
        ),
        new("Progress Ring", null,
            new ExampleDefinitionItem("Basic", typeof(ProgressRingBasicDemo))
        ),
        new("Effects", null,
            new ExampleDefinitionItem("Lighten", typeof(LightenDemo)),
            new ExampleDefinitionItem("InnerShadow", typeof(InnerShadowEffectDemo)),
            new ExampleDefinitionItem("FakeDropShadow", typeof(FakeDropShadowDemo)),
            new ExampleDefinitionItem("Gooey Ellipse", typeof(GooeyEllipseDemo))
        ),
        new("Transitions", null,
            new ExampleDefinitionItem("RippleBase", typeof(RippleBasic)),
            new ExampleDefinitionItem("BusyIndicator", typeof(TransitionBusyIndicatorDemo))
        ),
        new("TextShimmers", null,
            new ExampleDefinitionItem("UsingOpacityMask", typeof(TextShimmerUsingOpacityMask))
        ),
        new("Shape", null,
            new ExampleDefinitionItem("TriangleLoading", typeof(TriangleLoading)),
            new ExampleDefinitionItem("TriangleLoading2", typeof(TriangleLoading2)),
            new ExampleDefinitionItem("TriangleLoading3", typeof(TriangleLoading3)),
            new ExampleDefinitionItem("EllipseButton", typeof(EllipseButtonDemo)),
            new ExampleDefinitionItem("PointsAnimation", typeof(PointsAnimation))
        ),
        new("Buttons", null,
            new ExampleDefinitionItem("Demo 1", typeof(ButtonDesignDemo1)),
            new ExampleDefinitionItem("Demo 2", typeof(ButtonDesignDemo2))
        ),
        new("LongShadow", null,
            new ExampleDefinitionItem("Demo 1", typeof(LongShadowDemo1)),
            new ExampleDefinitionItem("Demo 2", typeof(LongShadowDemo2)),
            new ExampleDefinitionItem("Demo 3", typeof(LongShadowDemo3)),
            new ExampleDefinitionItem("Demo 4", typeof(LongShadowDemo4))
        ),
        new("GlowEffects", null,
            new ExampleDefinitionItem("Neon Love", typeof(NeonLoveDemo)),
            new ExampleDefinitionItem("Demo 1", typeof(GlowEffectDemo1))
        ),

            new("Waves", null,
            new ExampleDefinitionItem("Simple Waves", typeof(SimpleWaves)),
            new ExampleDefinitionItem("Simple Bubble Waves", typeof(SimpleBubbleWaves))
        ),
           new("AnimateProgressRing", null,
            new ExampleDefinitionItem("Hard Code", typeof(HardCodeAnimateProgressRing)),
            new ExampleDefinitionItem("Control Template", typeof(AnimateProgressRingUsingControlTemplate))
        ),
              new("WaveProgressBars", null,
            new ExampleDefinitionItem("Hard Code", typeof(HardCodeWaveProgressBar)),
            new ExampleDefinitionItem("Control Template", typeof(WaveProgressBarUsingControlTemplate))
        )
    };
}
