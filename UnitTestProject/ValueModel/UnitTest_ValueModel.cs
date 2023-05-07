using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using gencs;
using gencs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.ValueModel
{
    [TestClass]
    public class UnitTest_ValueModel
    {
        public UnitTest_ValueModel()
        {
        }

        [TestMethod]
        public void Test_object_ValueModel()
        {
            JsonNode jsonNode = new JsonObject
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
            TableEntity entity = Json.Deserialize<TableEntity>(jsonNode);
            ClassInfo classInfo = new ClassInfo
            {
                ClassName = "EntityObject",
                NameSpace = "UnitTestProject.ValueModel",
            };
            string code = Facade.CreateValueModel(classInfo, "entityObj" , entity);
            File.WriteAllText(@"../../../ValueModel/EntityObject.cs", code);

            string json1 = jsonNode.ToJsonString().Prettify();
            string json2 = Json.Serialize(new EntityObject().entityObj);
            //File.WriteAllText(@"c:\temp\gencs1.json", json1);
            //File.WriteAllText(@"c:\temp\gencs2.json", json2);
            Assert.AreEqual(json1, json2);
        }


        [TestMethod]
        public void Test_List_ValueModel()
        {
            JsonNode jsonNode = new JsonArray
            {
                new JsonObject
                {
                    ["tenantId"] = "devel",
                    ["scanElementId"] = "INT-1002#LANE-DET1",
                    ["name"] = "LANE-DET1",
                    ["intersectionId"] = "INT-1002",
                    ["shape"] = "lane/detector/L",
                    ["latitude"] = 1,
                    ["longitude"] = 1,
                    ["altitude"] = 0,
                    ["scaleX"] = 1,
                    ["scaleY"] = 1,
                    ["angle"] = 45,
                    ["scanValues"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["parameter"] = "ON",
                            ["number"] = 0,
                            ["status"] = "Red",
                            ["color"] = "Red",
                            ["priority"] = 0,
                            ["flash"] = false
                        },
                        new JsonObject
                        {
                            ["parameter"] = "OFF",
                            ["number"] = 0,
                            ["status"] = "Grey",
                            ["color"] = "Grey",
                            ["priority"] = 0,
                            ["flash"] = false
                        }
                    },
                    ["lastUpdated"] = "2023-05-02T14:44:40.563-05:00"
                },
                new JsonObject
                {
                    ["tenantId"] = "devel",
                    ["scanElementId"] = "INT-1002#LANE-DET2",
                    ["name"] = "LANE-DET2",
                    ["intersectionId"] = "INT-1002",
                    ["shape"] = "lane/detector/R",
                    ["latitude"] = 1.1,
                    ["longitude"] = 1.1,
                    ["altitude"] = 0,
                    ["scaleX"] = 1,
                    ["scaleY"] = 1,
                    ["angle"] = 0.1,
                    ["scanValues"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["parameter"] = "ON",
                            ["number"] = 0,
                            ["status"] = "Red",
                            ["color"] = "Red",
                            ["priority"] = 0,
                            ["flash"] = false
                        },
                        new JsonObject
                        {
                            ["parameter"] = "OFF",
                            ["number"] = 0,
                            ["status"] = "Grey",
                            ["color"] = "Grey",
                            ["priority"] = 0,
                            ["flash"] = false
                        }
                    },
                    ["lastUpdated"] = "2023-05-02T14:44:40.737-05:00"
                },
                new JsonObject
                {
                    ["tenantId"] = "devel",
                    ["scanElementId"] = "INT-1002#LANE-DET3",
                    ["name"] = "LANE-DET3",
                    ["intersectionId"] = "INT-1002",
                    ["shape"] = "lane/detector/T",
                    ["latitude"] = 1.1,
                    ["longitude"] = 1.1,
                    ["altitude"] = 0,
                    ["scaleX"] = 1,
                    ["scaleY"] = 1,
                    ["angle"] = 90,
                    ["scanValues"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["parameter"] = "ON",
                            ["number"] = 0,
                            ["status"] = "Red",
                            ["color"] = "Red",
                            ["priority"] = 0,
                            ["flash"] = false
                        },
                        new JsonObject
                        {
                            ["parameter"] = "OFF",
                            ["number"] = 0,
                            ["status"] = "Grey",
                            ["color"] = "Grey",
                            ["priority"] = 0,
                            ["flash"] = false
                        }
                    },
                    ["lastUpdated"] = "2023-05-02T14:44:40.873-05:00"
                },
                new JsonObject
                {
                    ["tenantId"] = "devel",
                    ["scanElementId"] = "INT-1002#LANE-NBT1",
                    ["name"] = "LANE-NBT1",
                    ["intersectionId"] = "INT-1002",
                    ["shape"] = "lane/L",
                    ["latitude"] = 1,
                    ["longitude"] = 1,
                    ["altitude"] = 0,
                    ["scaleX"] = 1,
                    ["scaleY"] = 1,
                    ["angle"] = 1,
                    ["scanValues"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["parameter"] = "Phase",
                            ["number"] = 1,
                            ["status"] = "1",
                            ["color"] = "Red",
                            ["priority"] = 0,
                            ["flash"] = false
                        },
                        new JsonObject
                        {
                            ["parameter"] = "Phase",
                            ["number"] = 1,
                            ["status"] = "1",
                            ["color"] = "Yellow",
                            ["priority"] = 0,
                            ["flash"] = false
                        },
                        new JsonObject
                        {
                            ["parameter"] = "Phase",
                            ["number"] = 1,
                            ["status"] = "1",
                            ["color"] = "Green",
                            ["priority"] = 0,
                            ["flash"] = false
                        }
                    },
                    ["lastUpdated"] = "2023-05-02T14:44:40.249-05:00"
                },
                new JsonObject
                {
                    ["tenantId"] = "devel",
                    ["scanElementId"] = "INT-1002#PED-DET1",
                    ["name"] = "PED-DET1",
                    ["intersectionId"] = "INT-1002",
                    ["shape"] = "pedcrossing/detector/NB",
                    ["latitude"] = 1,
                    ["longitude"] = 1,
                    ["altitude"] = 0,
                    ["scaleX"] = 1,
                    ["scaleY"] = 1,
                    ["angle"] = 10,
                    ["scanValues"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["parameter"] = "ON",
                            ["number"] = 0,
                            ["status"] = "Red",
                            ["color"] = "Red",
                            ["priority"] = 0,
                            ["flash"] = false
                        },
                        new JsonObject
                        {
                            ["parameter"] = "OFF",
                            ["number"] = 0,
                            ["status"] = "Grey",
                            ["color"] = "Grey",
                            ["priority"] = 0,
                            ["flash"] = false
                        }
                    },
                    ["lastUpdated"] = "2023-05-02T14:44:40.925-05:00"
                },
                new JsonObject
                {
                    ["tenantId"] = "devel",
                    ["scanElementId"] = "INT-1002#PED-NB",
                    ["name"] = "PED-NB",
                    ["intersectionId"] = "INT-1002",
                    ["shape"] = "pedcrossing/NB",
                    ["latitude"] = 0,
                    ["longitude"] = 0,
                    ["altitude"] = 0,
                    ["scaleX"] = 1,
                    ["scaleY"] = 1,
                    ["angle"] = 0,
                    ["scanValues"] = new JsonArray
                    {

                    },
                    ["lastUpdated"] = "2023-05-02T14:44:40.446-05:00"
                }
            };
            List<ScanElementEntity> entities = Json.Deserialize<List<ScanElementEntity>>(jsonNode);
            ClassInfo classInfo = new ClassInfo
            {
                ClassName = "EntityList",
                NameSpace = "UnitTestProject.ValueModel",
            };
            string code = Facade.CreateValueModel(classInfo, "entityList", entities);
            File.WriteAllText(@"../../../ValueModel/EntityList.cs", code);

            string json1 = jsonNode.ToJsonString().Prettify();
            string json2 = Json.Serialize(new EntityList().entityList);
            File.WriteAllText(@"c:\temp\gencs1.json", json1);
            File.WriteAllText(@"c:\temp\gencs2.json", json2);
            Assert.AreEqual(json1, json2);
        }

    }
}
