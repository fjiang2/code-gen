using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.ValueModel
{

    public class TableEntity 
    {
        public string TenantId { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public Intersection Intersection { get; set; }
    }

    public partial class Intersection
    {
        public List<Approach> Approaches { get; set; } = new();

        public List<Detector> Detectors { get; set; } = new();

        public List<PedDetector> PedDetectors { get; set; } = new();
    }

    public partial class Approach
    {
        public ApproachType ApproachType { get; set; }

        public List<Lane> Lanes { get; set; } = new();

        public List<PedCrossing> PedCrossings { get; set; } = new();

    }

    public partial class LanePhasing
    {

        public int ProtectedPhase { get; set; }

        public int PermissivePhase { get; set; }

        public int Overlap { get; set; }

        public int HpPreempt { get; set; }

        public int LpPreempt { get; set; }


    }

    public partial class Lane
    {
        public bool Show { get; set; }
        public string LaneName { get; set; } = string.Empty;

        public int Number { get; set; }

        public MovementType Movement { get; set; }

        public PhaseInfo PhaseInfo { get; set; } = new();

        public List<int> Detectors { get; set; } = new();

        public List<VehicleType> VehicleType { get; set; } = new();

        public TurnPropertiesType TurnProperties { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double SpeedLimit { get; set; }

        public MedianType MedianType { get; set; }

        public double MedianWidth { get; set; }

        public LanePhasing Phasing { get; set; } = new();
        public string ScanElementId { get; set; } = string.Empty;

    }

    public partial class PedCrossing
    {
        public string CrossingName { get; set; } = string.Empty;

        public PedCrossingType PedType { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public List<int> Detectors { get; set; } = new();

        public PedPhasing Phasing { get; set; } = new();
        public string ScanElementId { get; set; } = string.Empty;
    }

    public partial class PedPhasing
    {
        public int PedPhase { get; set; }

        public int PedOverlap { get; set; }

    }

    public partial class Detector
    {
        public bool Show { get; set; }

        public int Number { get; set; }

        public ChannelInfo ChannleInfo { get; set; } = new();

        public List<Purpose> Purpose { get; set; } = new();

        public List<DetectorType> Type { get; set; } = new();

        public CalculationType CalculationType { get; set; }

        public double SharedPct { get; set; }

        public double SpeedMph { get; set; }

        public double DistanceFt { get; set; }

        public MovementType Movement { get; set; }

        public string Position { get; set; } = string.Empty;

        public string LaneName { get; set; } = string.Empty;

        public List<DetectorPurpose> Purposes { get; set; } = new();

        public string ScanElementId { get; set; } = string.Empty;

    }

    public partial class SharedDetector
    {
        public int ChannelNumber { get; set; }

        public double SharedPercent { get; set; }

        public MovementType MovementType { get; set; }

    }

    public partial class PedDetector
    {
        public bool Show { get; set; }

        public string CrossingName { get; set; } = string.Empty;

        public int ChannelNumber { get; set; }

        public string ScanElementId { get; set; } = string.Empty;

    }

    public partial class PhaseInfo
    {
        public List<int> PhaseNumber { get; set; } = new();

        public string TrafficControllerId { get; set; } = string.Empty;

    }

    public partial class ChannelInfo
    {
        public int ChannelNumber { get; set; }

        public string TrafficControllerId { get; set; } = string.Empty;

    }


    /// <summary>
    /// SPM Purpose
    /// </summary>
    public enum Purpose
    {
        Normal = 0,

        TMC = 1,

    }


    /// <summary>
    /// SPM DetectorType
    /// </summary>
    public enum DetectorType
    {
        Stopbar = 0,

        Advanced = 1,

        Curbside = 2,

        Downstream = 3,

    }

    public enum ApproachType
    {
        NB,

        EB,

        SB,

        WB,

        NWB,

        NEB,

        SWB,

        SEB,

    }

    public enum MovementType
    {
        U,

        UL,

        SL,

        L,

        TWLT,

        TL,

        T,

        LTR,

        LR,

        TR,

        R,

        UR,

        ULR,

        AR,

        SR,

    }

    public enum PedCrossingType
    {
        Normal,
        Island,
        Scramble,
    }

    public enum VehicleType
    {
        [Description("General")]
        General,

        [Description("Public Transit Exclusive")]
        PublicTransitExclusive,

        [Description("Public Transit Semi Exclusive")]
        PublicTransitSemiExclusive,

        [Description("Taxi Ride Hailing")]
        TaxiRide_Hailing,

        [Description("Carpooling Ride sharing")]
        Carpooling_Ridesharing,

        [Description("Bicycle Unidirectional")]
        BicycleUni,

        [Description("Bicycle Bidirectional")]
        BicycleBi,

        [Description("HOV")]
        HOV,

        [Description("Restricted")]
        Restricted,
    }

    public enum MedianType
    {
        Physical,

        Painted,

        Cones,

        Barriers,

        TrafficChannels,

    }
    public enum TurnPropertiesType
    {
        None,

        Bay,

        Channelized,

    }

    [Flags]
    public enum DetectorPurpose
    {
        StopBar = 0x0001,
        TMC = 0x0002,
        Adv = 0x0004,
        RLM = 0x0008,

        Curb = 0x0010,
        ExitLane = 0x0020,
        Congest = 0x0040,
        System = 0x0080,

        Ramp = 0x0100,
        Mid = 0x0200,
        Queue = 0x0400,
        Bike = 0x0800,

        Trans = 0x10000,
        SpeedTrap = 0x2000,
        VehExt = 0x4000,
        BikeExt = 0x8000,

        Devices = 0x10000,
    }
    public enum CalculationType
    {
        None,

        SharedPercent,

        Subdetector,

    }

    public class ScanElementEntity
    {
        public string TenantId { get; set; } = string.Empty;
        public string ScanElementId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string IntersectionId { get; set; } = string.Empty;
        public string Shape { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public double ScaleX { get; set; }
        public double ScaleY { get; set; }
        public double Angle { get; set; }
        public List<ScanProperty> ScanValues { get; set; } = new List<ScanProperty>();
        public DateTime LastUpdated { get; set; }
    }
    public class ScanProperty
    {
        public string Parameter { get; set; } = string.Empty;
        public int Number { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int Priority { get; set; }
        public bool Flash { get; set; }
    }

}

