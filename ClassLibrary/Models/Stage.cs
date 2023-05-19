using System.ComponentModel;

namespace ClassLibrary.Models;

public class Stage
{
    public enum LoadSheddingStage
    {
        [EnumValue("Unknown")]
        Unknown,
        [EnumValue("None")]
        None,
        [EnumValue("Stage 1")]
        Stage1,
        [EnumValue("Stage 2")]
        Stage2,
        [EnumValue("Stage 3")]
        Stage3,
        [EnumValue("Stage 4")]
        Stage4,
        [EnumValue("Stage 5")]
        Stage5,
        [EnumValue("Stage 6")]
        Stage6,
        [EnumValue("Stage 7")]
        Stage7,
        [EnumValue("Stage 8")]
        Stage8
    }

    public static class LoadSheddingStageExtensions
    {
        public static string ToString(LoadSheddingStage stage)
        {
            switch (stage)
            {
                case LoadSheddingStage.None:
                    return "None";
                case LoadSheddingStage.Stage1:
                    return "Stage 1";
                case LoadSheddingStage.Stage2:
                    return "Stage 2";
                case LoadSheddingStage.Stage3:
                    return "Stage 3";
                case LoadSheddingStage.Stage4:
                    return "Stage 4";
                case LoadSheddingStage.Stage5:
                    return "Stage 5";
                case LoadSheddingStage.Stage6:
                    return "Stage 6";
                case LoadSheddingStage.Stage7:
                    return "Stage 7";
                case LoadSheddingStage.Stage8:
                    return "Stage 8";
                default:
                    return "Unknown";
            }
        }
    }
}