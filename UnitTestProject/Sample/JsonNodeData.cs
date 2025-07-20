using System.Text.Json.Nodes;

namespace UnitTestProject.Sample
{
    public partial class JsonNodeData
    {
        public JsonNode jsonNode = new JsonObject
        {
            ["version"] = "1.0",
            ["dataVersion"] = "85.1.65",
            ["dataType"] = "RealtimeBuffer",
            ["headerSize"] = 0,
            ["verCode"] = 0,
            ["fields"] = new JsonArray
            {
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "controllerVerBuild",
                    ["offset"] = 0,
                    ["byteLength"] = 2,
                    ["dataType"] = "UShort",
                    ["startBit"] = 0,
                    ["bitLength"] = 16,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 409,
                    ["max"] = 409
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "phaseGreen",
                    ["offset"] = 2,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "phaseYellow",
                    ["offset"] = 6,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "phaseRed",
                    ["offset"] = 10,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "pedWalk",
                    ["offset"] = 14,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "pedClear",
                    ["offset"] = 18,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "pedDontWalk",
                    ["offset"] = 22,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "olapGreen",
                    ["offset"] = 26,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "olapYellow",
                    ["offset"] = 30,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "olapRed",
                    ["offset"] = 34,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "phaseCall",
                    ["offset"] = 38,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "pedCall",
                    ["offset"] = 42,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "phaseNext",
                    ["offset"] = 46,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "ringTermReason",
                    ["offset"] = 50,
                    ["byteLength"] = 8,
                    ["count"] = 8,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Enum",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 1,
                        ["dataType"] = "Byte",
                        ["startBit"] = 0,
                        ["bitLength"] = 8,
                        ["values"] = new JsonArray
                        {
                            new JsonObject
                            {
                                ["eId"] = 0,
                                ["eValue"] = "None"
                            },
                            new JsonObject
                            {
                                ["eId"] = 1,
                                ["eValue"] = "GapOut"
                            },
                            new JsonObject
                            {
                                ["eId"] = 2,
                                ["eValue"] = "MaxOut"
                            },
                            new JsonObject
                            {
                                ["eId"] = 3,
                                ["eValue"] = "forceOff"
                            },
                            new JsonObject
                            {
                                ["eId"] = 4,
                                ["eValue"] = "IntrlAdv"
                            }
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "timebaseCounter",
                    ["offset"] = 58,
                    ["byteLength"] = 2,
                    ["dataType"] = "UShort",
                    ["startBit"] = 0,
                    ["bitLength"] = 16,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 65535
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "localCounter",
                    ["offset"] = 60,
                    ["byteLength"] = 2,
                    ["dataType"] = "UShort",
                    ["startBit"] = 0,
                    ["bitLength"] = 16,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 65535
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "freeStatus",
                    ["offset"] = 62,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Other"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "CoorActive"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "Command"
                        },
                        new JsonObject
                        {
                            ["eId"] = 4,
                            ["eValue"] = "Trans"
                        },
                        new JsonObject
                        {
                            ["eId"] = 5,
                            ["eValue"] = "Input"
                        },
                        new JsonObject
                        {
                            ["eId"] = 6,
                            ["eValue"] = "Pattern"
                        },
                        new JsonObject
                        {
                            ["eId"] = 7,
                            ["eValue"] = "PlanErr"
                        },
                        new JsonObject
                        {
                            ["eId"] = 8,
                            ["eValue"] = "CycleErr"
                        },
                        new JsonObject
                        {
                            ["eId"] = 9,
                            ["eValue"] = "SplitErr"
                        },
                        new JsonObject
                        {
                            ["eId"] = 10,
                            ["eValue"] = "OffsetErr"
                        },
                        new JsonObject
                        {
                            ["eId"] = 11,
                            ["eValue"] = "Failed"
                        },
                        new JsonObject
                        {
                            ["eId"] = 16,
                            ["eValue"] = "CoOlapErr"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "coordStatus",
                    ["offset"] = 63,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "Off"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Normal"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "Short-way"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "Long-way"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "coordMode",
                    ["offset"] = 64,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "coordSource",
                    ["offset"] = 65,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "Other"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Test"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "Remote"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "SYS"
                        },
                        new JsonObject
                        {
                            ["eId"] = 4,
                            ["eValue"] = "SysTBC"
                        },
                        new JsonObject
                        {
                            ["eId"] = 5,
                            ["eValue"] = "SysExt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 6,
                            ["eValue"] = "BackupTBC"
                        },
                        new JsonObject
                        {
                            ["eId"] = 7,
                            ["eValue"] = "BackupExt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 8,
                            ["eValue"] = "TBC"
                        },
                        new JsonObject
                        {
                            ["eId"] = 9,
                            ["eValue"] = "External"
                        },
                        new JsonObject
                        {
                            ["eId"] = 10,
                            ["eValue"] = "PRE"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "cycleTime",
                    ["offset"] = 66,
                    ["byteLength"] = 2,
                    ["dataType"] = "UShort",
                    ["startBit"] = 0,
                    ["bitLength"] = 16,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 65535
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "cycleOffset",
                    ["offset"] = 68,
                    ["byteLength"] = 2,
                    ["dataType"] = "UShort",
                    ["startBit"] = 0,
                    ["bitLength"] = 16,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 65535
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "ringSequence",
                    ["offset"] = 70,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "phaseMode",
                    ["offset"] = 71,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "User"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Std8"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "QSeq"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "8Seq"
                        },
                        new JsonObject
                        {
                            ["eId"] = 4,
                            ["eValue"] = "Diamond"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "splitNumber",
                    ["offset"] = 72,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "activePreempt",
                    ["offset"] = 73,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "TwDate",
                    ["id"] = "time",
                    ["offset"] = 74,
                    ["byteLength"] = 7
                },
                new JsonObject
                {
                    ["parameterType"] = "Struct",
                    ["id"] = "StatusBits1",
                    ["offset"] = 81,
                    ["byteLength"] = 1,
                    ["fields"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "nazAdp_SygnAct",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 0,
                            ["bitLength"] = 1
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "minTime",
                    ["offset"] = 82,
                    ["byteLength"] = 8,
                    ["count"] = 8,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Number",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 1,
                        ["dataType"] = "Byte",
                        ["startBit"] = 0,
                        ["bitLength"] = 8,
                        ["scaledFactor"] = 1,
                        ["scaledOffset"] = 0,
                        ["min"] = 0,
                        ["max"] = 255
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "pedTime",
                    ["offset"] = 90,
                    ["byteLength"] = 8,
                    ["count"] = 8,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Number",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 1,
                        ["dataType"] = "Byte",
                        ["startBit"] = 0,
                        ["bitLength"] = 8,
                        ["scaledFactor"] = 1,
                        ["scaledOffset"] = 0,
                        ["min"] = 0,
                        ["max"] = 255
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "maxTime",
                    ["offset"] = 98,
                    ["byteLength"] = 16,
                    ["count"] = 8,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Number",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 2,
                        ["dataType"] = "UShort",
                        ["startBit"] = 0,
                        ["bitLength"] = 16,
                        ["scaledFactor"] = 1,
                        ["scaledOffset"] = 0,
                        ["min"] = 0,
                        ["max"] = 65535
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "ringPhaseOn",
                    ["offset"] = 114,
                    ["byteLength"] = 8,
                    ["count"] = 8,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Number",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 1,
                        ["dataType"] = "Byte",
                        ["startBit"] = 0,
                        ["bitLength"] = 8,
                        ["scaledFactor"] = 1,
                        ["scaledOffset"] = 0,
                        ["min"] = 0,
                        ["max"] = 255
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "altPhaseOption",
                    ["offset"] = 122,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "altPhaseTimes",
                    ["offset"] = 123,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "altDetectorOptions",
                    ["offset"] = 124,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "altCIR",
                    ["offset"] = 125,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "schedEvent",
                    ["offset"] = 126,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "schedAction",
                    ["offset"] = 127,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "controllerModel",
                    ["offset"] = 128,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "softwareVersionBase",
                    ["offset"] = 129,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "softwareVersionRev",
                    ["offset"] = 130,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "controllerType",
                    ["offset"] = 131,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "softwareVersionLetter",
                    ["offset"] = 132,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "offsetError",
                    ["offset"] = 133,
                    ["byteLength"] = 2,
                    ["dataType"] = "UShort",
                    ["startBit"] = 0,
                    ["bitLength"] = 16,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 65535
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "detectorCalls",
                    ["offset"] = 135,
                    ["byteLength"] = 8,
                    ["count"] = 64
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "lightRailCalls",
                    ["offset"] = 144,
                    ["byteLength"] = 2,
                    ["dataType"] = "UShort",
                    ["startBit"] = 0,
                    ["bitLength"] = 16,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 65535
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "alarmStatus",
                    ["offset"] = 146,
                    ["byteLength"] = 16,
                    ["count"] = 128
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "splitReportCycle",
                    ["offset"] = 162,
                    ["byteLength"] = 2,
                    ["dataType"] = "UShort",
                    ["startBit"] = 0,
                    ["bitLength"] = 16,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 65535
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "splitReportOffset",
                    ["offset"] = 164,
                    ["byteLength"] = 2,
                    ["dataType"] = "UShort",
                    ["startBit"] = 0,
                    ["bitLength"] = 16,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 65535
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "splitReportSplitMeasured",
                    ["offset"] = 166,
                    ["byteLength"] = 64,
                    ["count"] = 32,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Number",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 2,
                        ["dataType"] = "UShort",
                        ["startBit"] = 0,
                        ["bitLength"] = 16,
                        ["scaledFactor"] = 1,
                        ["scaledOffset"] = 0,
                        ["min"] = 0,
                        ["max"] = 65535
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "splitReportSplitProgrammed",
                    ["offset"] = 230,
                    ["byteLength"] = 64,
                    ["count"] = 32,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Number",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 2,
                        ["dataType"] = "UShort",
                        ["startBit"] = 0,
                        ["bitLength"] = 16,
                        ["scaledFactor"] = 1,
                        ["scaledOffset"] = 0,
                        ["min"] = 0,
                        ["max"] = 65535
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "phaseOn",
                    ["offset"] = 294,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "phaseOmits",
                    ["offset"] = 298,
                    ["byteLength"] = 2,
                    ["count"] = 16
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "overrideMinuteLeft",
                    ["offset"] = 300,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "splitReportCycleNumber",
                    ["offset"] = 301,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "splitReportTermReasonsGapOut",
                    ["offset"] = 302,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "splitReportTermReasonsMaxOut",
                    ["offset"] = 306,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "splitReportTermReasonsForceOff",
                    ["offset"] = 310,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "overviewControllerA",
                    ["offset"] = 314,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "OFF"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "FLASH_LS"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "FLASH_CVM"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "TIMING"
                        },
                        new JsonObject
                        {
                            ["eId"] = 4,
                            ["eValue"] = "STOPTIME"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "overviewControllerB",
                    ["offset"] = 315,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "None"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "StartupFlash"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "AutoFlash"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "PreemptFlash"
                        },
                        new JsonObject
                        {
                            ["eId"] = 4,
                            ["eValue"] = "CntrlFault"
                        },
                        new JsonObject
                        {
                            ["eId"] = 5,
                            ["eValue"] = "Spare"
                        },
                        new JsonObject
                        {
                            ["eId"] = 6,
                            ["eValue"] = "FreeMode"
                        },
                        new JsonObject
                        {
                            ["eId"] = 7,
                            ["eValue"] = "CoordAct"
                        },
                        new JsonObject
                        {
                            ["eId"] = 8,
                            ["eValue"] = "MEMA_StopTime1_2"
                        },
                        new JsonObject
                        {
                            ["eId"] = 9,
                            ["eValue"] = "NEMA_ManuCtrl"
                        },
                        new JsonObject
                        {
                            ["eId"] = 10,
                            ["eValue"] = "SDLC_Not_CommEstab"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "overviewControllerC",
                    ["offset"] = 316,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "None"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Port1_Flt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "Conflict_Flt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "Field_Flt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 4,
                            ["eValue"] = "Cycle_Fail"
                        },
                        new JsonObject
                        {
                            ["eId"] = 5,
                            ["eValue"] = "Initial_Err"
                        },
                        new JsonObject
                        {
                            ["eId"] = 6,
                            ["eValue"] = "Spare"
                        },
                        new JsonObject
                        {
                            ["eId"] = 7,
                            ["eValue"] = "Critical_Flt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 8,
                            ["eValue"] = "SIUAMU_Err"
                        },
                        new JsonObject
                        {
                            ["eId"] = 9,
                            ["eValue"] = "DB_wrt_prblm"
                        },
                        new JsonObject
                        {
                            ["eId"] = 10,
                            ["eValue"] = "CommNotEstab"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "overviewMMUStatus",
                    ["offset"] = 317,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "OK"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Fault"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "Reset"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "NoData"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "overviewMMUFaultCode",
                    ["offset"] = 318,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "None"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "CVM_Flt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "DC24_I_Flt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "DC24_II_Flt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 4,
                            ["eValue"] = "CONFL_Flt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 5,
                            ["eValue"] = "REDFAIL_Flt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 6,
                            ["eValue"] = "PORT1_Flt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 7,
                            ["eValue"] = "CLRNC_Flt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 8,
                            ["eValue"] = "DIAG_Flt"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "offsetErrorSign",
                    ["offset"] = 319,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "ShortwayorSync"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Longway"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "overviewCabinetA",
                    ["offset"] = 320,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "OK"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Local-MMUFlash"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "NoData"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "overviewCabinetB",
                    ["offset"] = 321,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "Blank"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "NEMA_localFlashInpt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "MMU_FlashInpt"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "schedDayPlan",
                    ["offset"] = 322,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "schedSchedule",
                    ["offset"] = 323,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "alertTemperature1",
                    ["offset"] = 324,
                    ["byteLength"] = 2,
                    ["dataType"] = "UShort",
                    ["startBit"] = 0,
                    ["bitLength"] = 16,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 65535
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "alertTemperature2",
                    ["offset"] = 326,
                    ["byteLength"] = 2,
                    ["dataType"] = "UShort",
                    ["startBit"] = 0,
                    ["bitLength"] = 16,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 65535
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "channelGreen",
                    ["offset"] = 328,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "channelYellow",
                    ["offset"] = 332,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "channelRed",
                    ["offset"] = 336,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "coordOpModeSys",
                    ["offset"] = 340,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "coordOpModeNext",
                    ["offset"] = 341,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "coordOpModeTBC",
                    ["offset"] = 342,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "coordOpModeRemote",
                    ["offset"] = 343,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "coordOpModeTest",
                    ["offset"] = 344,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "coordOpModeTOD",
                    ["offset"] = 345,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "coordOpModeExt",
                    ["offset"] = 346,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "coordOpModeState",
                    ["offset"] = 347,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "Off"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Normal"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "Short-way"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "Long-way"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "coordOpModeActive",
                    ["offset"] = 348,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "coordOpModeSource",
                    ["offset"] = 349,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "Other"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Test"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "Remote"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "SYS"
                        },
                        new JsonObject
                        {
                            ["eId"] = 4,
                            ["eValue"] = "SysTBC"
                        },
                        new JsonObject
                        {
                            ["eId"] = 5,
                            ["eValue"] = "SysExt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 6,
                            ["eValue"] = "BackupTBC"
                        },
                        new JsonObject
                        {
                            ["eId"] = 7,
                            ["eValue"] = "BackupExt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 8,
                            ["eValue"] = "TBC"
                        },
                        new JsonObject
                        {
                            ["eId"] = 9,
                            ["eValue"] = "External"
                        },
                        new JsonObject
                        {
                            ["eId"] = 10,
                            ["eValue"] = "PRE"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "ringSplitCountdown",
                    ["offset"] = 350,
                    ["byteLength"] = 16,
                    ["count"] = 8,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Number",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 2,
                        ["dataType"] = "UShort",
                        ["startBit"] = 0,
                        ["bitLength"] = 16,
                        ["scaledFactor"] = 1,
                        ["scaledOffset"] = 0,
                        ["min"] = 0,
                        ["max"] = 65535
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Number",
                    ["id"] = "spare",
                    ["offset"] = 366,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["scaledFactor"] = 1,
                    ["scaledOffset"] = 0,
                    ["min"] = 0,
                    ["max"] = 255
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "extendTime",
                    ["offset"] = 367,
                    ["byteLength"] = 8,
                    ["count"] = 8,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Number",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 1,
                        ["dataType"] = "Byte",
                        ["startBit"] = 0,
                        ["bitLength"] = 8,
                        ["scaledFactor"] = 1,
                        ["scaledOffset"] = 0,
                        ["min"] = 0,
                        ["max"] = 255
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "phaseCheck",
                    ["offset"] = 375,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "phaseHold",
                    ["offset"] = 379,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "phaseOmit",
                    ["offset"] = 383,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "pedOmit",
                    ["offset"] = 387,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "pedDetCall",
                    ["offset"] = 391,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "pedDetAlarm",
                    ["offset"] = 395,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "Struct",
                    ["id"] = "CabinetInputs",
                    ["offset"] = 399,
                    ["byteLength"] = 1,
                    ["fields"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "NEMA_TestA",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 0,
                            ["bitLength"] = 1
                        },
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "NEMA_TestB",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 1,
                            ["bitLength"] = 1
                        },
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "NEMA_ManuCtrl",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 2,
                            ["bitLength"] = 1
                        },
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "NEMA_IntAdv",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 3,
                            ["bitLength"] = 1
                        },
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "NEMA_StopTime1_2",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 4,
                            ["bitLength"] = 1
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "nctipUnitFlashStatus",
                    ["offset"] = 400,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Other"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "None"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "Auto"
                        },
                        new JsonObject
                        {
                            ["eId"] = 4,
                            ["eValue"] = "LocalInpt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 5,
                            ["eValue"] = "MMURptFlt"
                        },
                        new JsonObject
                        {
                            ["eId"] = 6,
                            ["eValue"] = "MMUInput"
                        },
                        new JsonObject
                        {
                            ["eId"] = 7,
                            ["eValue"] = "Startup"
                        },
                        new JsonObject
                        {
                            ["eId"] = 8,
                            ["eValue"] = "Preempt"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Struct",
                    ["id"] = "NctipUnitAlarmStatus1",
                    ["offset"] = 401,
                    ["byteLength"] = 1,
                    ["fields"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "CycleFault",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 0,
                            ["bitLength"] = 1
                        },
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "CoordFault",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 1,
                            ["bitLength"] = 1
                        },
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "CoordFail",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 2,
                            ["bitLength"] = 1
                        },
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "CycleFail",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 3,
                            ["bitLength"] = 1
                        },
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "MMUFlash",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 4,
                            ["bitLength"] = 1
                        },
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "LocalFlash",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 5,
                            ["bitLength"] = 1
                        },
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "LocalFree",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 6,
                            ["bitLength"] = 1
                        },
                        new JsonObject
                        {
                            ["parameterType"] = "BoolBit",
                            ["id"] = "CoordActive",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 7,
                            ["bitLength"] = 1
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "specFuncs",
                    ["offset"] = 402,
                    ["byteLength"] = 1,
                    ["count"] = 8
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "tspActive",
                    ["offset"] = 403,
                    ["byteLength"] = 1,
                    ["count"] = 8
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "tspExtend",
                    ["offset"] = 404,
                    ["byteLength"] = 1,
                    ["count"] = 8
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "tspReduce",
                    ["offset"] = 405,
                    ["byteLength"] = 1,
                    ["count"] = 8
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "olapAux",
                    ["offset"] = 406,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "olapTimerActive",
                    ["offset"] = 410,
                    ["byteLength"] = 4,
                    ["count"] = 32
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "olapTimerValue",
                    ["offset"] = 414,
                    ["byteLength"] = 32,
                    ["count"] = 32,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Number",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 1,
                        ["dataType"] = "Byte",
                        ["startBit"] = 0,
                        ["bitLength"] = 8,
                        ["scaledFactor"] = 1,
                        ["scaledOffset"] = 0,
                        ["min"] = 0,
                        ["max"] = 255
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "splitCountdown",
                    ["offset"] = 446,
                    ["byteLength"] = 64,
                    ["count"] = 32,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Number",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 2,
                        ["dataType"] = "UShort",
                        ["startBit"] = 0,
                        ["bitLength"] = 16,
                        ["scaledFactor"] = 1,
                        ["scaledOffset"] = 0,
                        ["min"] = 0,
                        ["max"] = 65535
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "activePreemptInterval",
                    ["offset"] = 510,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "None"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Begin"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "TrackClr"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "Min"
                        },
                        new JsonObject
                        {
                            ["eId"] = 4,
                            ["eValue"] = "Return"
                        },
                        new JsonObject
                        {
                            ["eId"] = 5,
                            ["eValue"] = "Dwell"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "preemptInputs",
                    ["offset"] = 511,
                    ["byteLength"] = 2,
                    ["count"] = 16
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "preemptLinkedInputs",
                    ["offset"] = 513,
                    ["byteLength"] = 2,
                    ["count"] = 16
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "preemptRequestState",
                    ["offset"] = 515,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "Clear"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "Active"
                        },
                        new JsonObject
                        {
                            ["eId"] = 2,
                            ["eValue"] = "DelayDone"
                        },
                        new JsonObject
                        {
                            ["eId"] = 3,
                            ["eValue"] = "Lock"
                        },
                        new JsonObject
                        {
                            ["eId"] = 4,
                            ["eValue"] = "MaxInhibit"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Enum",
                    ["id"] = "preempt_type",
                    ["offset"] = 516,
                    ["byteLength"] = 1,
                    ["dataType"] = "Byte",
                    ["startBit"] = 0,
                    ["bitLength"] = 8,
                    ["values"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["eId"] = 0,
                            ["eValue"] = "Emerg"
                        },
                        new JsonObject
                        {
                            ["eId"] = 1,
                            ["eValue"] = "LRV"
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "BoolArray",
                    ["id"] = "detectorCalls_65_128",
                    ["offset"] = 517,
                    ["byteLength"] = 8,
                    ["count"] = 64
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "peer_ip_address",
                    ["offset"] = 525,
                    ["byteLength"] = 60,
                    ["count"] = 15,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Array",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 4,
                        ["count"] = 4,
                        ["elementType"] = new JsonObject
                        {
                            ["parameterType"] = "Number",
                            ["id"] = "Items",
                            ["offset"] = 0,
                            ["byteLength"] = 1,
                            ["dataType"] = "Byte",
                            ["startBit"] = 0,
                            ["bitLength"] = 8,
                            ["scaledFactor"] = 1,
                            ["scaledOffset"] = 0,
                            ["min"] = 0,
                            ["max"] = 255
                        }
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "peer_tx_count",
                    ["offset"] = 585,
                    ["byteLength"] = 15,
                    ["count"] = 15,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Number",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 1,
                        ["dataType"] = "Byte",
                        ["startBit"] = 0,
                        ["bitLength"] = 8,
                        ["scaledFactor"] = 1,
                        ["scaledOffset"] = 0,
                        ["min"] = 0,
                        ["max"] = 255
                    }
                },
                new JsonObject
                {
                    ["parameterType"] = "Array",
                    ["id"] = "peer_rx_missed",
                    ["offset"] = 600,
                    ["byteLength"] = 15,
                    ["count"] = 15,
                    ["elementType"] = new JsonObject
                    {
                        ["parameterType"] = "Number",
                        ["id"] = "Items",
                        ["offset"] = 0,
                        ["byteLength"] = 1,
                        ["dataType"] = "Byte",
                        ["startBit"] = 0,
                        ["bitLength"] = 8,
                        ["scaledFactor"] = 1,
                        ["scaledOffset"] = 0,
                        ["min"] = 0,
                        ["max"] = 255
                    }
                }
            }
        };
    }
}