using System;
using System.Collections.Generic;
using UnitTestProject.ValueModel;

namespace UnitTestProject.ValueModel
{
	public partial class EntityObject
	{
		public TableEntity entityObj = new TableEntity
		{
			TenantId = "devel",
			Type = "Layout#INT-1002#2023-05-02",
			Intersection = new Intersection
			{
				Approaches = new List<Approach>
				{
					
					new Approach
					{
						ApproachType = ApproachType.NB,
						Lanes = new List<Lane>
						{
							
							new Lane
							{
								Show = true,
								LaneName = "NBT1",
								Number = 1,
								Movement = MovementType.L,
								PhaseInfo = new PhaseInfo
								{
									PhaseNumber = new List<int>
									{
										2
									},
									TrafficControllerId = "DEV-101"
								},
								Detectors = new List<int>
								{
									3,
									2,
									1
								},
								VehicleType = new List<VehicleType>
								{
									VehicleType.PublicTransitExclusive
								},
								TurnProperties = TurnPropertiesType.Channelized,
								Length = 1,
								Width = 1,
								SpeedLimit = 30,
								MedianType = MedianType.TrafficChannels,
								MedianWidth = 1,
								Phasing = new LanePhasing
								{
									ProtectedPhase = 2,
									PermissivePhase = 1,
									Overlap = 1,
									HpPreempt = 10,
									LpPreempt = 0
								},
								ScanElementId = "INT-1002#LANE-NBT1"
							}
						},
						PedCrossings = new List<PedCrossing>
						{
							
							new PedCrossing
							{
								CrossingName = "NB Ped Xing",
								PedType = PedCrossingType.Normal,
								Length = 0,
								Width = 0,
								Detectors = new List<int>
								{
									3,
									1
								},
								Phasing = new PedPhasing
								{
									PedPhase = 0,
									PedOverlap = 0
								},
								ScanElementId = "INT-1002#PED-NB"
							}
						}
					}
				},
				Detectors = new List<Detector>
				{
					
					new Detector
					{
						Show = false,
						Number = 1,
						ChannleInfo = new ChannelInfo
						{
							ChannelNumber = 1,
							TrafficControllerId = "DEV-101"
						},
						Purpose = new List<Purpose>
						{
							Purpose.TMC,
							Purpose.Normal
						},
						Type = new List<DetectorType>
						{
							DetectorType.Stopbar,
							DetectorType.Advanced
						},
						CalculationType = CalculationType.None,
						SharedPct = 0,
						SpeedMph = 0,
						DistanceFt = 30,
						Movement = MovementType.L,
						Position = "Ingress",
						LaneName = "T",
						Purposes = new List<DetectorPurpose>
						{
							DetectorPurpose.TMC,
							DetectorPurpose.Adv
						},
						ScanElementId = "INT-1002#LANE-DET1"
					},
					
					new Detector
					{
						Show = false,
						Number = 2,
						ChannleInfo = new ChannelInfo
						{
							ChannelNumber = 2,
							TrafficControllerId = "DEV-101"
						},
						Purpose = new List<Purpose>
						{
							Purpose.TMC,
							Purpose.Normal
						},
						Type = new List<DetectorType>
						{
							DetectorType.Stopbar,
							DetectorType.Advanced
						},
						CalculationType = CalculationType.SharedPercent,
						SharedPct = 30,
						SpeedMph = 0,
						DistanceFt = 40,
						Movement = MovementType.L,
						Position = "Ingress",
						LaneName = "TR",
						Purposes = new List<DetectorPurpose>
						{
							DetectorPurpose.TMC,
							DetectorPurpose.Adv
						},
						ScanElementId = "INT-1002#LANE-DET2"
					},
					
					new Detector
					{
						Show = false,
						Number = 2,
						ChannleInfo = new ChannelInfo
						{
							ChannelNumber = 2,
							TrafficControllerId = "DEV-101"
						},
						Purpose = new List<Purpose>
						{
							Purpose.TMC,
							Purpose.Normal
						},
						Type = new List<DetectorType>
						{
							DetectorType.Stopbar,
							DetectorType.Advanced
						},
						CalculationType = CalculationType.SharedPercent,
						SharedPct = 30,
						SpeedMph = 0,
						DistanceFt = 40,
						Movement = MovementType.T,
						Position = "Ingress",
						LaneName = "TR",
						Purposes = new List<DetectorPurpose>
						{
							DetectorPurpose.TMC,
							DetectorPurpose.Adv
						},
						ScanElementId = "INT-1002#LANE-DET2"
					},
					
					new Detector
					{
						Show = false,
						Number = 2,
						ChannleInfo = new ChannelInfo
						{
							ChannelNumber = 2,
							TrafficControllerId = "DEV-101"
						},
						Purpose = new List<Purpose>
						{
							Purpose.TMC,
							Purpose.Normal
						},
						Type = new List<DetectorType>
						{
							DetectorType.Stopbar,
							DetectorType.Advanced
						},
						CalculationType = CalculationType.SharedPercent,
						SharedPct = 40,
						SpeedMph = 0,
						DistanceFt = 40,
						Movement = MovementType.R,
						Position = "Ingress",
						LaneName = "TR",
						Purposes = new List<DetectorPurpose>
						{
							DetectorPurpose.TMC,
							DetectorPurpose.Adv
						},
						ScanElementId = "INT-1002#LANE-DET2"
					},
					
					new Detector
					{
						Show = false,
						Number = 3,
						ChannleInfo = new ChannelInfo
						{
							ChannelNumber = 3,
							TrafficControllerId = "DEV-101"
						},
						Purpose = new List<Purpose>
						{
							Purpose.TMC,
							Purpose.Normal
						},
						Type = new List<DetectorType>
						{
							DetectorType.Stopbar,
							DetectorType.Advanced
						},
						CalculationType = CalculationType.SharedPercent,
						SharedPct = 30,
						SpeedMph = 0,
						DistanceFt = 40,
						Movement = MovementType.L,
						Position = "Ingress",
						LaneName = "TR",
						Purposes = new List<DetectorPurpose>
						{
							DetectorPurpose.TMC,
							DetectorPurpose.Adv
						},
						ScanElementId = "INT-1002#LANE-DET3"
					},
					
					new Detector
					{
						Show = false,
						Number = 3,
						ChannleInfo = new ChannelInfo
						{
							ChannelNumber = 3,
							TrafficControllerId = "DEV-101"
						},
						Purpose = new List<Purpose>
						{
							Purpose.TMC,
							Purpose.Normal
						},
						Type = new List<DetectorType>
						{
							DetectorType.Stopbar,
							DetectorType.Advanced
						},
						CalculationType = CalculationType.SharedPercent,
						SharedPct = 70,
						SpeedMph = 0,
						DistanceFt = 40,
						Movement = MovementType.T,
						Position = "Ingress",
						LaneName = "TR",
						Purposes = new List<DetectorPurpose>
						{
							DetectorPurpose.TMC,
							DetectorPurpose.Adv
						},
						ScanElementId = "INT-1002#LANE-DET3"
					}
				},
				PedDetectors = new List<PedDetector>
				{
					
					new PedDetector
					{
						Show = true,
						CrossingName = "NB",
						ChannelNumber = 1,
						ScanElementId = "INT-1002#PED-DET1"
					}
				}
			}
		};
	}
}