using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using gencs;
using gencs.Models;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.ValueModel
{
    [TestClass]
    public class UnitTest_ValueModel
    {
        private readonly JsonNode jsonNode = new JsonObject
        {
            ["tenantId"] = "devel",
            ["type"] = "Layout#INT-1002#2023-05-02",
            ["intersection"] = new JsonObject
            {
                ["approaches"] = new JsonArray
                {
                  new JsonObject
                  {
                    ["approachType"] = "nb",
                    ["lanes"] = new JsonArray
                    {
                      new JsonObject
                      {
                        ["show"] = true,
                        ["laneName"] = "NBT1",
                        ["number"] = 1,
                        ["movement"] = "l",
                        ["phaseInfo"] = new JsonObject
                        {
                          ["phaseNumber"] = new JsonArray
                          {
                            2
                          },
                          ["trafficControllerId"] = "DEV-101"
                        },
                        ["detectors"] = new JsonArray
                        {
                          3,
                          2,
                          1
                        },
                        ["vehicleType"] = new JsonArray
                        {
                          "publicTransitExclusive"
                        },
                        ["turnProperties"] = "channelized",
                        ["length"] = 1,
                        ["width"] = 1,
                        ["speedLimit"] = 30,
                        ["medianType"] = "trafficChannels",
                        ["medianWidth"] = 1,
                        ["phasing"] = new JsonObject
                        {
                            ["protectedPhase"] = 2,
                            ["permissivePhase"] = 1,
                            ["overlap"] = 1,
                            ["hpPreempt"] = 10,
                            ["lpPreempt"] = 0
                        },
                        ["scanElementId"] = "INT-1002#LANE-NBT1"
                      }
                    },
                    ["pedCrossings"] = new JsonArray
                    {
                      new JsonObject
                      {
                        ["crossingName"] = "NB Ped Xing",
                        ["pedType"] = "normal",
                        ["length"] = 0,
                        ["width"] = 0,
                        ["detectors"] = new JsonArray
                        {
                          3,
                          1
                        },
                        ["phasing"] = new JsonObject
                        {
                          ["pedPhase"] = 0,
                          ["pedOverlap"] = 0
                        },
                        ["scanElementId"] = "INT-1002#PED-NB"
                      }
                    }
                  }
                },
                ["detectors"] = new JsonArray
                {
                  new JsonObject
                  {
                    ["show"] = false,
                    ["number"] = 1,
                    ["channleInfo"] = new JsonObject
                    {
                      ["channelNumber"] = 1,
                      ["trafficControllerId"] = "DEV-101"
                    },
                    ["purpose"] = new JsonArray
                    {
                      "tmc",
                      "normal"
                    },
                    ["type"] = new JsonArray
                    {
                      "stopbar",
                      "advanced"
                    },
                    ["calculationType"] = "none",
                    ["sharedPct"] = 0,
                    ["speedMph"] = 0,
                    ["distanceFt"] = 30,
                    ["movement"] = "l",
                    ["position"] = "Ingress",
                    ["laneName"] = "T",
                    ["purposes"] = new JsonArray
                    {
                      "tmc",
                      "adv"
                    },
                    ["scanElementId"] = "INT-1002#LANE-DET1"
                  },
                  new JsonObject
                  {
                    ["show"] = false,
                    ["number"] = 2,
                    ["channleInfo"] = new JsonObject
                    {
                      ["channelNumber"] = 2,
                      ["trafficControllerId"] = "DEV-101"
                    },
                    ["purpose"] = new JsonArray
                    {
                      "tmc",
                      "normal"
                    },
                    ["type"] = new JsonArray
                    {
                      "stopbar",
                      "advanced"
                    },
                    ["calculationType"] = "sharedPercent",
                    ["sharedPct"] = 30,
                    ["speedMph"] = 0,
                    ["distanceFt"] = 40,
                    ["movement"] = "l",
                    ["position"] = "Ingress",
                    ["laneName"] = "TR",
                    ["purposes"] = new JsonArray
                    {
                      "tmc",
                      "adv"
                    },
                    ["scanElementId"] = "INT-1002#LANE-DET2"
                  },
                  new JsonObject
                  {
                    ["show"] = false,
                    ["number"] = 2,
                    ["channleInfo"] = new JsonObject
                    {
                      ["channelNumber"] = 2,
                      ["trafficControllerId"] = "DEV-101"
                    },
                    ["purpose"] = new JsonArray
                    {
                      "tmc",
                      "normal"
                    },
                    ["type"] = new JsonArray
                    {
                      "stopbar",
                      "advanced"
                    },
                    ["calculationType"] = "sharedPercent",
                    ["sharedPct"] = 30,
                    ["speedMph"] = 0,
                    ["distanceFt"] = 40,
                    ["movement"] = "t",
                    ["position"] = "Ingress",
                    ["laneName"] = "TR",
                    ["purposes"] = new JsonArray
                    {
                      "tmc",
                      "adv"
                    },
                    ["scanElementId"] = "INT-1002#LANE-DET2"
                  },
                  new JsonObject
                  {
                    ["show"] = false,
                    ["number"] = 2,
                    ["channleInfo"] = new JsonObject
                    {
                      ["channelNumber"] = 2,
                      ["trafficControllerId"] = "DEV-101"
                    },
                    ["purpose"] = new JsonArray
                    {
                      "tmc",
                      "normal"
                    },
                    ["type"] = new JsonArray
                    {
                      "stopbar",
                      "advanced"
                    },
                    ["calculationType"] = "sharedPercent",
                    ["sharedPct"] = 40,
                    ["speedMph"] = 0,
                    ["distanceFt"] = 40,
                    ["movement"] = "r",
                    ["position"] = "Ingress",
                    ["laneName"] = "TR",
                    ["purposes"] = new JsonArray
                    {
                      "tmc",
                      "adv"
                    },
                    ["scanElementId"] = "INT-1002#LANE-DET2"
                  },
                  new JsonObject
                  {
                    ["show"] = false,
                    ["number"] = 3,
                    ["channleInfo"] = new JsonObject
                    {
                      ["channelNumber"] = 3,
                      ["trafficControllerId"] = "DEV-101"
                    },
                    ["purpose"] = new JsonArray
                    {
                      "tmc",
                      "normal"
                    },
                    ["type"] = new JsonArray
                    {
                      "stopbar",
                      "advanced"
                    },
                    ["calculationType"] = "sharedPercent",
                    ["sharedPct"] = 30,
                    ["speedMph"] = 0,
                    ["distanceFt"] = 40,
                    ["movement"] = "l",
                    ["position"] = "Ingress",
                    ["laneName"] = "TR",
                    ["purposes"] = new JsonArray
                    {
                      "tmc",
                      "adv"
                    },
                    ["scanElementId"] = "INT-1002#LANE-DET3"
                  },
                  new JsonObject
                  {
                    ["show"] = false,
                    ["number"] = 3,
                    ["channleInfo"] = new JsonObject
                    {
                      ["channelNumber"] = 3,
                      ["trafficControllerId"] = "DEV-101"
                    },
                    ["purpose"] = new JsonArray
                    {
                      "tmc",
                      "normal"
                    },
                    ["type"] = new JsonArray
                    {
                      "stopbar",
                      "advanced"
                    },
                    ["calculationType"] = "sharedPercent",
                    ["sharedPct"] = 70,
                    ["speedMph"] = 0,
                    ["distanceFt"] = 40,
                    ["movement"] = "t",
                    ["position"] = "Ingress",
                    ["laneName"] = "TR",
                    ["purposes"] = new JsonArray
                    {
                      "tmc",
                      "adv"
                    },
                    ["scanElementId"] = "INT-1002#LANE-DET3"
                  }
                },
                ["pedDetectors"] = new JsonArray
                {
                  new JsonObject
                  {
                    ["show"] = true,
                    ["crossingName"] = "NB",
                    ["channelNumber"] = 1,
                    ["scanElementId"] = "INT-1002#PED-DET1"
                  }
                }
            },
        };


        public UnitTest_ValueModel()
        {
        }

        [TestMethod]
        public void TestValueModel()
        {
            TableEntity intersectionEntity = Json.Deserialize<TableEntity>(jsonNode);
            ClassInfo classInfo = new ClassInfo
            {
                ClassName = "EntityValue",
                NameSpace = "UnitTestProject.ValueModel",
            };
            string code = Facade.CreateValueModel(classInfo, "entityObj" , intersectionEntity);
            File.WriteAllText(@"../../../ValueModel/EntityValue.cs", code);

            string json1 = jsonNode.ToJsonString().Prettify();
            string json2 = Json.Serialize(new EntityValue().entityObj);
            File.WriteAllText(@"c:\temp\gencs1.json", json1);
            File.WriteAllText(@"c:\temp\gencs2.json", json2);
            Assert.AreEqual(json1, json2);
        }
    }
}
