using System;
using System.Collections.Generic;
using UnitTestProject.ValueModel;

namespace UnitTestProject.ValueModel
{
	public partial class EntityList
	{
		public List<ScanElementEntity> entityList = new List<ScanElementEntity>
		{
			
			new ScanElementEntity
			{
				TenantId = "devel",
				ScanElementId = "INT-1002#LANE-DET1",
				Name = "LANE-DET1",
				IntersectionId = "INT-1002",
				Shape = "lane/detector/L",
				Latitude = 1,
				Longitude = 1,
				Altitude = 0,
				ScaleX = 1,
				ScaleY = 1,
				Angle = 45,
				ScanValues = new List<ScanProperty>
				{
					
					new ScanProperty
					{
						Parameter = "ON",
						Number = 0,
						Status = "Red",
						Color = "Red",
						Priority = 0,
						Flash = false
					},
					
					new ScanProperty
					{
						Parameter = "OFF",
						Number = 0,
						Status = "Grey",
						Color = "Grey",
						Priority = 0,
						Flash = false
					}
				},
				LastUpdated = new DateTime(2023, 5, 2, 14, 44, 40, 563, DateTimeKind.Local)
			},
			
			new ScanElementEntity
			{
				TenantId = "devel",
				ScanElementId = "INT-1002#LANE-DET2",
				Name = "LANE-DET2",
				IntersectionId = "INT-1002",
				Shape = "lane/detector/R",
				Latitude = 1.1,
				Longitude = 1.1,
				Altitude = 0,
				ScaleX = 1,
				ScaleY = 1,
				Angle = 0.1,
				ScanValues = new List<ScanProperty>
				{
					
					new ScanProperty
					{
						Parameter = "ON",
						Number = 0,
						Status = "Red",
						Color = "Red",
						Priority = 0,
						Flash = false
					},
					
					new ScanProperty
					{
						Parameter = "OFF",
						Number = 0,
						Status = "Grey",
						Color = "Grey",
						Priority = 0,
						Flash = false
					}
				},
				LastUpdated = new DateTime(2023, 5, 2, 14, 44, 40, 737, DateTimeKind.Local)
			},
			
			new ScanElementEntity
			{
				TenantId = "devel",
				ScanElementId = "INT-1002#LANE-DET3",
				Name = "LANE-DET3",
				IntersectionId = "INT-1002",
				Shape = "lane/detector/T",
				Latitude = 1.1,
				Longitude = 1.1,
				Altitude = 0,
				ScaleX = 1,
				ScaleY = 1,
				Angle = 90,
				ScanValues = new List<ScanProperty>
				{
					
					new ScanProperty
					{
						Parameter = "ON",
						Number = 0,
						Status = "Red",
						Color = "Red",
						Priority = 0,
						Flash = false
					},
					
					new ScanProperty
					{
						Parameter = "OFF",
						Number = 0,
						Status = "Grey",
						Color = "Grey",
						Priority = 0,
						Flash = false
					}
				},
				LastUpdated = new DateTime(2023, 5, 2, 14, 44, 40, 873, DateTimeKind.Local)
			},
			
			new ScanElementEntity
			{
				TenantId = "devel",
				ScanElementId = "INT-1002#LANE-NBT1",
				Name = "LANE-NBT1",
				IntersectionId = "INT-1002",
				Shape = "lane/L",
				Latitude = 1,
				Longitude = 1,
				Altitude = 0,
				ScaleX = 1,
				ScaleY = 1,
				Angle = 1,
				ScanValues = new List<ScanProperty>
				{
					
					new ScanProperty
					{
						Parameter = "Phase",
						Number = 1,
						Status = "1",
						Color = "Red",
						Priority = 0,
						Flash = false
					},
					
					new ScanProperty
					{
						Parameter = "Phase",
						Number = 1,
						Status = "1",
						Color = "Yellow",
						Priority = 0,
						Flash = false
					},
					
					new ScanProperty
					{
						Parameter = "Phase",
						Number = 1,
						Status = "1",
						Color = "Green",
						Priority = 0,
						Flash = false
					}
				},
				LastUpdated = new DateTime(2023, 5, 2, 14, 44, 40, 249, DateTimeKind.Local)
			},
			
			new ScanElementEntity
			{
				TenantId = "devel",
				ScanElementId = "INT-1002#PED-DET1",
				Name = "PED-DET1",
				IntersectionId = "INT-1002",
				Shape = "pedcrossing/detector/NB",
				Latitude = 1,
				Longitude = 1,
				Altitude = 0,
				ScaleX = 1,
				ScaleY = 1,
				Angle = 10,
				ScanValues = new List<ScanProperty>
				{
					
					new ScanProperty
					{
						Parameter = "ON",
						Number = 0,
						Status = "Red",
						Color = "Red",
						Priority = 0,
						Flash = false
					},
					
					new ScanProperty
					{
						Parameter = "OFF",
						Number = 0,
						Status = "Grey",
						Color = "Grey",
						Priority = 0,
						Flash = false
					}
				},
				LastUpdated = new DateTime(2023, 5, 2, 14, 44, 40, 925, DateTimeKind.Local)
			},
			
			new ScanElementEntity
			{
				TenantId = "devel",
				ScanElementId = "INT-1002#PED-NB",
				Name = "PED-NB",
				IntersectionId = "INT-1002",
				Shape = "pedcrossing/NB",
				Latitude = 0,
				Longitude = 0,
				Altitude = 0,
				ScaleX = 1,
				ScaleY = 1,
				Angle = 0,
				ScanValues = new List<ScanProperty>
				{
					
				},
				LastUpdated = new DateTime(2023, 5, 2, 14, 44, 40, 446, DateTimeKind.Local)
			}
		};
	}
}